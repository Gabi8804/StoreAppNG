using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess
{
    public class SpecsRepository<Specs>
    {
        private readonly SmartStoreDBContext db;

        public SpecsRepository()
        {
            db = new SmartStoreDBContext();
        }


        public List<Entities.Spec> ReadByIds(List<int> specIds)
        {
            return db.Specs.Where(x => specIds.Contains(x.SpecId)).ToList();
        }
    }
}
