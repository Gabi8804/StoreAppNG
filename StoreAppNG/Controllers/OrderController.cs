using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.BusinessLogic;
using StoreApp.BusinessLogic.BusinessEntities;
using StoreAppNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreApp.Controllers
{


    [Authorize]
    public class OrderController : Controller
    {
        private readonly ProductHandler productHandler;
        private readonly OrderHandler orderHandler;
        //private readonly UserHandler userHandler;
        public OrderController()
        {
            productHandler = new ProductHandler();
            orderHandler = new OrderHandler();
            //userHandler = new UserHandler();
        }
        // GET: Order
        public ActionResult Cart()
        {
            var products = new List<ProductViewModel>();
            foreach (var p in ShoppingBag.orderList)
            {
                products.Add(new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                });
            }
            var order = new OrderViewModel()
            {
                Products = products
            };

            return View(order);
        }

        [HttpPost]
        [ActionName("Cart")]
        public ActionResult PlaceOrder(OrderViewModel order)
        {
            
                var addressModel = new AddressModel
                {
                    AddressLine1 = order.AddressLine1,
                    AddressLine2 = order.AddressLine2,
                    City = order.City,
                    Postcode = order.Postcode,
                    Province = order.Province
                };

                //var userId = userHandler.GetUserIdByName(User.Identity.Name);
                var addressId = orderHandler.CreateAddressAndGetId(addressModel);
                foreach (var p in order.Products)
                {
                    orderHandler.PlaceOrder(p.ProductId, p.Quantity, 1, addressId);
                    RemoveFromCart(p.ProductId.ToString());
                }
                return RedirectToAction("Index", "Home");
           
        }

        [HttpPost]
        public ActionResult AddToCart(string ProductId)
        {
            var prodId = int.Parse(ProductId);
            var product = productHandler.GetProduct(prodId);

            var productForCart = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = 1,
                ProductId = product.ProductId
            };

            ShoppingBag.AddToCart(productForCart);

            return null;
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string ProductId)
        {
            var prodId = int.Parse(ProductId);
            var product = productHandler.GetProduct(prodId);

            var productForCart = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = 1,
                ProductId = product.ProductId
            };

            ShoppingBag.RemoveFromCart(productForCart);

            return null;
        }

        [HttpPost]
        public JsonResult GetProductsOfCart()
        {
            var products = ShoppingBag.orderList.Select(x => x.ProductId).ToArray();

            return Json(products); ;
        }

    }
}