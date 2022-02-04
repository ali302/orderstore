using System;
using System.Collections.Generic;

namespace OrderStore.Domain.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProductComposite = new HashSet<OrderProductComposite>();
        }

        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomeId { get; set; }

        public virtual Customer Custome { get; set; }
        public virtual ICollection<OrderProductComposite> OrderProductComposite { get; set; }
    }
}
