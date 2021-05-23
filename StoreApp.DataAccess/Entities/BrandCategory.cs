using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class BrandCategory
    {
        public BrandCategory()
        {
            Products = new HashSet<Product>();
        }

        public int BrandCategoryId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
