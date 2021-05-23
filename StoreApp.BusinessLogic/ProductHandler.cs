using StoreApp.BusinessLogic.BusinessEntities;
using StoreApp.DataAccess;
using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic
{
    public class ProductHandler
    {
        private readonly GenericRepository<Product> productRepo;
        private readonly ProductRepository<Product> productCustomRepo;
        private readonly BrandCategoryRepository<BrandCategory> brandCategoryRepo;
        private readonly GenericRepository<BrandCategory> brandCategoryGenericRepo;
        private readonly BrandHandler brandHandler;
        private readonly CategoryHandler categoryHandler;
        private readonly SpecificationsHandler specHandler;

        public ProductHandler()
        {
            productCustomRepo = new ProductRepository<Product>();
            productRepo = new GenericRepository<Product>();
            brandCategoryRepo = new BrandCategoryRepository<BrandCategory>();
            brandCategoryGenericRepo = new GenericRepository<BrandCategory>();
            categoryHandler = new CategoryHandler();
            brandHandler = new BrandHandler();
            specHandler = new SpecificationsHandler();
        }
        public List<ProductModel> GetAllProducts()
        {
            var productList = productRepo.ReadAll();
            var prodListBL = new List<ProductModel>();

            foreach (var prod in productList)
            {
                prodListBL.Add(new ProductModel(prod));
            }
            return prodListBL;
        }
        public ProductModel GetProduct(int productId)
        {
            var product = productRepo.ReadById(productId);
            var brandAndCategory = brandCategoryGenericRepo.ReadById(product.BrandCategoryId);

            var brandModel = brandHandler.GetById(brandAndCategory.BrandId);
            var categoryModel = categoryHandler.GetById(brandAndCategory.CategoryId);
            var specModelList = specHandler.GetSpecificationsByProductId(productId);
            var prodModel = new ProductModel(product)
            {
                Brand = brandModel,
                Category = categoryModel,
                Specifications=specModelList
                };
            
            return prodModel;
        }

        public int CreateProductAndGetId(ProductModel entity)
        {
            var product = new Product()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                BrandCategoryId = entity.BrandCategoryId,
                Image = entity.Image,
                Quantity=entity.Quantity
              
            };

            return productCustomRepo.CreateAndGetId(product);
        }

        public int GetBrandCategoryId(BrandModel brandModel, CategoryModel categoryModel)
        {
            return brandCategoryRepo.ReadByIds(brandModel.BrandId, categoryModel.CategoryId);
        }

        public List<BrandModel> GetBrandsOfSelectedCategory(int categoryId)
        {
            var brandIdsList = brandCategoryRepo.GetBrandIdsByCategoryId(categoryId);
            return brandHandler.ReadByIds(brandIdsList);
        }

        public void Update(ProductModel productToUpdate)
        {
            productRepo.Update(new Product()
            {
                ProductId=productToUpdate.ProductId,
                Name = productToUpdate.Name,
                Description = productToUpdate.Description,
                Price = productToUpdate.Price,
                BrandCategoryId = productToUpdate.BrandCategoryId,
                Image = productToUpdate.Image,
                DateCreated= productToUpdate.DateCreated
            });
        }
        public void Delete(int productId)
        {
            specHandler.DeleteFromProdCatSpec(productId);
            productRepo.Delete(productId);
        }
    }
}
