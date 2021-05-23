using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class CategorySpec
    {
        public CategorySpec()
        {
            ProdCatSpecs = new HashSet<ProdCatSpec>();
        }

        public int CategorySpecsId { get; set; }
        public int CategoryId { get; set; }
        public int SpecId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Spec Spec { get; set; }
        public virtual ICollection<ProdCatSpec> ProdCatSpecs { get; set; }
    }
}
