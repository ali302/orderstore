using System;
using System.Collections.Generic;

namespace OrderStore.Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProductComposite = new HashSet<OrderProductComposite>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public virtual ICollection<OrderProductComposite> OrderProductComposite { get; set; }
    }
}
