using System;
using System.Collections.Generic;

namespace OrderStore.Domain.Models
{
    public partial class OrderProductComposite
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
