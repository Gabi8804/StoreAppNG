using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic.BusinessEntities
{
  public  class AddressModel
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
