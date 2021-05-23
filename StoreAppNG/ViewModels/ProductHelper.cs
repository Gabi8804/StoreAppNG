using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppNG.ViewModels
{
    public class ProductHelper
    {
        private readonly ProductHandler productHandler;
        private readonly CategoryHandler categoryHandler;
        private readonly BrandHandler brandHandler;
        public ProductHelper()
        {
            productHandler = new ProductHandler();
            brandHandler = new BrandHandler();
            categoryHandler = new CategoryHandler();
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
                Brands = brandHandler.GetBrands().Select(b => new SelectListItem
                {
                    Value = b.BrandId.ToString(),
                    Text = b.Name
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
