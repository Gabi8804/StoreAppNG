using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic.BusinessEntities
{
   public class SpecificationsModel
    {
        public int SpecId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CategorySpecId { get; set; }
        public int Prod_CatSpecId { get; set; }
    }
}
