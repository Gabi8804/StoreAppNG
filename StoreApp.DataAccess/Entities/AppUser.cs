using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? LastKnownAddressId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
