using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class ProdCatSpec
    {
        public int ProdCatSpecId { get; set; }
        public int ProductId { get; set; }
        public int CategorySpecsId { get; set; }
        public string SpecValue { get; set; }

        public virtual CategorySpec CategorySpecs { get; set; }
        public virtual Product Product { get; set; }
    }
}
