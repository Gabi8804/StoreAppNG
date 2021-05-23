using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAppNG.ViewModels
{
    public class SpecificationsListViewModel
    {
        public List<SpecificationsViewModel> Specifications { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Prod_CatSpecId { get; set; }
        

        public SpecificationsListViewModel()
        {
            Specifications = new List<SpecificationsViewModel>();
        }
    }
}