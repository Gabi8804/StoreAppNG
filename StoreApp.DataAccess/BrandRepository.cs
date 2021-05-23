using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
    public class BrandRepository<Brands>
    {

        private readonly SmartStoreDBContext db;

        public BrandRepository()
        {
            db = new SmartStoreDBContext();
        }

        public List<Entities.Brand> ReadByIds(List<int> brandIds)
        {
          return db.Brands.Where(x => brandIds.Contains(x.BrandId)).ToList();
        }

        public List<Entities.Brand> ReadAll()
        {
            return db.Brands.ToList();
        }
    }
}
