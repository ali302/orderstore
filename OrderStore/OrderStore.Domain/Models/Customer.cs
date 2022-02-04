using System;
using System.Collections.Generic;

namespace OrderStore.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
