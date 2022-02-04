using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;
using System;

namespace OrderStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public UnitOfWork(ApplicationDbContext applicationDBContext,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this._context = applicationDBContext;

            this.Orders = orderRepository;
            this.Products = productRepository;
        }
        public bool AddOrder(string OrderName, int productID, int customerID)
        {
            //Check if Product Exists
            //Check if Customer Exists

                this.Orders.Add(new Domain.Models.Orders { OrderName = OrderName, OrderDate = DateTime.Now, CustomeId = customerID });
                this.Complete();
                return true;

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
