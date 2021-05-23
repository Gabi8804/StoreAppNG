using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
            ProdCatSpecs = new HashSet<ProdCatSpec>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int BrandCategoryId { get; set; }
        public string Image { get; set; }
        public DateTime? DateCreated { get; set; }
        public int Quantity { get; set; }

        public virtual BrandCategory BrandCategory { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
        public virtual ICollection<ProdCatSpec> ProdCatSpecs { get; set; }
    }
}
