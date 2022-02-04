using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace OrderStore.CQRS
{
    public class Select : Repository.UnitOfWork
    {
        /// <summary>
        /// CQRS class for Query commands
        /// </summary>
        /// <param name="applicationDBContext"></param>
        /// <param name="orderRepository"></param>
        /// <param name="productRepository"></param>
        public Select(ApplicationDbContext applicationDBContext, IOrderRepository orderRepository, IProductRepository productRepository) : base(applicationDBContext, orderRepository, productRepository)
        {
        }
    }
}
