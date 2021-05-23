using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            BrandCategories = new HashSet<BrandCategory>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BrandCategory> BrandCategories { get; set; }
    }
}
