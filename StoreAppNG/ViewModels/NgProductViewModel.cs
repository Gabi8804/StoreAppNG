using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppNG.ViewModels
{
    public class NgProductViewModel
    {

        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
