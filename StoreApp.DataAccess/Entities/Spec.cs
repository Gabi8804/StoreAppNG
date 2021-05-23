using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class Spec
    {
        public Spec()
        {
            CategorySpecs = new HashSet<CategorySpec>();
        }

        public int SpecId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CategorySpec> CategorySpecs { get; set; }
    }
}
