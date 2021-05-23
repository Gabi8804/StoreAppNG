using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic.BusinessEntities
{
    public class ProductModel
    {
        public ProductModel()
        {

        }
        public ProductModel(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            BrandCategoryId = product.BrandCategoryId;
            DateCreated = (DateTime)product.DateCreated;
            Quantity = product.Quantity;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int BrandCategoryId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public BrandModel Brand { get; set; }
        public CategoryModel Category { get; set; }
        public List<SpecificationsModel> Specifications { get; set; }

    }
}
