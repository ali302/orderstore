using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace OrderStore.CQRS
{
    /// <summary>
    /// CQRS Class for Insert Update Commands.
    /// </summary>
    public class InsertUpdate : Repository.UnitOfWork
    {
        public InsertUpdate(ApplicationDbContext applicationDBContext, IOrderRepository orderRepository, IProductRepository productRepository) : base(applicationDBContext, orderRepository, productRepository)
        {
        }
    }
}
