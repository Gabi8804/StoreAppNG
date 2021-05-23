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
   public class CategoryHandler
    {
        private readonly GenericRepository<Category> categoryRepo;

        public CategoryHandler()
        {
            categoryRepo = new GenericRepository<Category>();
        }

        public CategoryModel GetById(int id)
        {
            var category = categoryRepo.ReadById(id);
            return new CategoryModel(){
                CategoryId=category.CategoryId,
                Name = category.Name
            };
        }

        public List<CategoryModel> GetCategories()
        {
            var categoryList = categoryRepo.ReadAll();
            var categoryListBL = new List<CategoryModel>();
            foreach (var category in categoryList)
            {

                categoryListBL.Add(new CategoryModel()
                {
                    Name = category.Name,
                    CategoryId = category.CategoryId,
                });
            }
            return categoryListBL;
        }

    }
}
