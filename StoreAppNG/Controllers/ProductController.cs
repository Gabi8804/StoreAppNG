using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.BusinessLogic;
using StoreApp.BusinessLogic.BusinessEntities;
using StoreAppNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Controllers
{
  [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductHandler productHandler;
        private readonly CategoryHandler categoryHandler;
        private readonly BrandHandler brandHandler;

        public ProductController()
        {
            productHandler = new ProductHandler();
            brandHandler = new BrandHandler();
            categoryHandler = new CategoryHandler();
        }

        // GET: Product list
        
        public ActionResult Index()
        {
            var productList = new List<ProductViewModel>();
            var products = productHandler.GetAllProducts();

            foreach (var product in products)
            {
                productList.Add(new ProductViewModel
                {
                    ProductId = product.ProductId,
                    BrandCategoryId = product.BrandCategoryId,
                    Name = product.Name,
                    Price = product.Price
                });
            }

            return View(productList);
        }

        // GET: Product/Create
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var product = new ProductViewModel
            {
                Categories = categoryHandler.GetCategories().Select(c=> new SelectListItem
                {
                    Value=c.CategoryId.ToString(),
                    Text=c.Name
                })
        };
        return View(product);
        }


        // POST: Product/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var brandModel = new BrandModel()
                {
                    BrandId = product.Brand.BrandId,
                    Name = product.Brand.Name
                };
                var categoryModel = new CategoryModel()
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name
                };
                var BrandCategoryId = productHandler.GetBrandCategoryId(brandModel, categoryModel);

                var productToCreate = new ProductModel
                {
                    BrandCategoryId = BrandCategoryId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    DateCreated = DateTime.Now
                };
                var productId = productHandler.CreateProductAndGetId(productToCreate);

                return RedirectToAction("Create", "Specifications", new SpecificationsListViewModel
                {
                    ProductId = productId,
                    CategoryId = product.Category.CategoryId
                });
            }
            else
                return View(product);
        }



        [HttpPost]
        public JsonResult GetBrands(int categoryId)
        {
            var brandsOfCategory = productHandler.GetBrandsOfSelectedCategory(categoryId);
            var listOfBrands = new List<BrandViewModel>();

            foreach(var b in brandsOfCategory)
            {
                listOfBrands.Add(new BrandViewModel
                {
                    BrandId=b.BrandId,
                    Name=b.Name 
                });
            }
            return Json(listOfBrands);
        }

        // GET: Product/View/id
        [ActionName("View")]
        [HttpGet]
        public ActionResult ViewProduct(int id)
        {
            var product = GetProductById(id);
            return View(product);
        }


        // GET: Product/Edit/id
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = GetProductById(id);
            return View(product);
        }
        // GET: Product/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            productHandler.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var brandModel = new BrandModel()
                {
                    BrandId = product.Brand.BrandId,
                    Name = product.Brand.Name
                };
                var categoryModel = new CategoryModel()
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name
                };
                product.BrandCategoryId = productHandler.GetBrandCategoryId(brandModel, categoryModel);

                productHandler.Update(new ProductModel()
                {
                    ProductId = product.ProductId,
                    BrandCategoryId = product.BrandCategoryId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    DateCreated=product.DateCreated
                });

                return RedirectToAction("View", "Product", new { id = product.ProductId });
            }else
                return RedirectToAction("Edit");
        }

        public ProductViewModel GetProductById(int id)
        {
            var produdctModel = productHandler.GetProduct(id);

            var specList = new List<SpecificationsViewModel>();
            foreach (var s in produdctModel.Specifications)
            {
                specList.Add(new SpecificationsViewModel
                {
                    CatSpecId = s.CategorySpecId,
                    Name = s.Name,
                    SpecId = s.SpecId,
                    Value = s.Value
                });
            }
            var product = new ProductViewModel
            {
              Categories = categoryHandler.GetCategories().Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                }),
              Brands= brandHandler.GetBrands().Select(b=> new SelectListItem
              {
                  Value=b.BrandId.ToString(),
                  Text=b.Name
              }),
                Category = new CategoryViewModel
                {
                    CategoryId = produdctModel.Category.CategoryId,
                    Name = produdctModel.Category.Name
                },
                Brand = new BrandViewModel
                {
                    BrandId = produdctModel.Brand.BrandId,
                    Name = produdctModel.Brand.Name
                },
                DateCreated = produdctModel.DateCreated,
                Description = produdctModel.Description,
                Specifications = specList,
                Name = produdctModel.Name,
                Price = produdctModel.Price,
                ProductId = produdctModel.ProductId,
                BrandCategoryId = produdctModel.BrandCategoryId

            };
            return product;
        }

        
    }
}