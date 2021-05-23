using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
