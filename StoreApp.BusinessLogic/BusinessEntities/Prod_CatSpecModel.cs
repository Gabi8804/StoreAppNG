using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic.BusinessEntities
{
    public class Prod_CatSpecModel
    {
        public int Prod_CatSpecId { get; set; }
        public int ProductId { get; set; }
        public int CategorySpecId{get;set;}
        public string SpecValue { get; set; }
    }
}
