using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
