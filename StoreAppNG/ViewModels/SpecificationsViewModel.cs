using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAppNG.ViewModels
{
    public class SpecificationsViewModel
    {
        public int SpecId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int CatSpecId { get; set; }
    }
}