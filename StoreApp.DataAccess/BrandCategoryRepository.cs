using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
   public class BrandCategoryRepository<BrandCategories>
    {

        private readonly SmartStoreDBContext db;
        
        public BrandCategoryRepository()
        {
            db = new SmartStoreDBContext();
        }
        public int ReadByIds(int id1, int id2)
        {
            return db.BrandCategories.Where(x => x.BrandId == id1 && x.CategoryId == id2).Select(x => x.BrandCategoryId).FirstOrDefault();
        }

        public List<int> GetBrandIdsByCategoryId(int id)
        {
            return db.BrandCategories.Where(x => x.CategoryId == id).Select(x => x.BrandId).ToList();
        }
        
    }
}
