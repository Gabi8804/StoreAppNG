using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
  public class CategorySpecRepository<CategorySpecs>
    {

        private readonly SmartStoreDBContext db;

        public CategorySpecRepository()
        {
            db = new SmartStoreDBContext();
        }
        public List<Entities.CategorySpec> ReadAllBySpecIds(int categoryId)
        {
            return db.CategorySpecs.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<Entities.CategorySpec> GetAllByIds(IEnumerable<int> categorySpecIds)
        {
            return db.CategorySpecs.Where(x => categorySpecIds.Contains(x.CategorySpecsId)).ToList();
        }

    }
}
