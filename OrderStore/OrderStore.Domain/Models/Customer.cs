using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderStore.OrderStore.Domain.Models
{
    public class Customer
    {
        int CustomerID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string PostalCode { get; set; }
    }
}
