using OrderStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderStore.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetOrdersByOrderName(string orderName);
        bool UpdateOrderNameById(int id, string name);
         bool DeleteOrderById(int id);
    }
}
