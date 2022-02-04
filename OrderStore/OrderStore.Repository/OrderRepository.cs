using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderStore.Repository
{
   public class OrderRepository: GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context): base(context)
        {

        }
     
        async Task<IEnumerable<Orders>> IOrderRepository.GetOrdersByOrderName(string orderName)
        {
            return await _context.Orders.Where(c => c.OrderName.Contains(orderName)).ToListAsync();

        }
        public bool DeleteOrderById(int id)
        {
            var delEntity = _context.Orders.Where(d => d.OrderId == id).FirstOrDefault();
            _context.Orders.Remove(delEntity);
            _context.SaveChanges();
            return true;

        }
        public bool UpdateOrderNameById(int id,string name)
        {
            _context.Orders.FirstOrDefault(d => d.OrderId == id).OrderName = name;
            _context.SaveChanges();
            return true;
        }
     
    }
}
