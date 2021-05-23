using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAppNG.ViewModels
{
    public class OrderViewModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public OrderViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}