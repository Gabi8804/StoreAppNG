using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAppNG.ViewModels
{
    public static class ShoppingBag
    {
        public static List<ProductViewModel> orderList = new List<ProductViewModel>();

        public static void AddToCart(ProductViewModel product)
        {
            if (orderList.Where(x => x.ProductId == product.ProductId).ToList().Count() == 0)
            {
                orderList.Add(new ProductViewModel
                {
                    Name = product.Name,
                    Quantity = product.Quantity,
                    ProductId = product.ProductId,
                    Price = product.Price
                });
            }
            else
            {
                for (int i = 0; i < orderList.Count(); i++)
                {
                    if (orderList[i].ProductId == product.ProductId)
                    {
                        orderList[i].Quantity++;
                        break;
                    }
                }
            }
        }
        public static void RemoveFromCart(ProductViewModel product)
        {
            orderList.Remove(product);
        }
    }
}