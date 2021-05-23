using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Category
    {
        public Category()
        {
            BrandCategories = new HashSet<BrandCategory>();
            CategorySpecs = new HashSet<CategorySpec>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BrandCategory> BrandCategories { get; set; }
        public virtual ICollection<CategorySpec> CategorySpecs { get; set; }
    }
}
