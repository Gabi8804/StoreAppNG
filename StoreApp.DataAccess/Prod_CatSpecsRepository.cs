using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
   public class Prod_CatSpecsRepository<Prod_CatSpec>
    {

        private readonly SmartStoreDBContext db;

        public Prod_CatSpecsRepository()
        {
            db = new SmartStoreDBContext();
        }

        public void CreateMultiple(List<Entities.ProdCatSpec> prod_CatSpecs)
        {
           
            db.ProdCatSpecs.AddRange(prod_CatSpecs);
            db.SaveChanges();
        }
        public List<Entities.ProdCatSpec> GetProd_CatSpecsByProductId(int productId)
        {
            return db.ProdCatSpecs.Where(x => x.ProductId == productId).ToList();
        }

        public void DeleteMultiple(int productId)
        {
            var prod_CatSpecList = db.ProdCatSpecs
                .Where(x => x.ProductId == productId);
            db.ProdCatSpecs.RemoveRange(prod_CatSpecList);
            db.SaveChanges();
        }
    }
}
