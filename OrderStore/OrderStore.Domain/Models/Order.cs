using System;
using System.Collections.Generic;

namespace OrderStore.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public float TotalPrice { get { float price = 0;  Products.ForEach(p => price += p.Price); return price; } }
        public List<Product> Products { get; set; }

    }
}
