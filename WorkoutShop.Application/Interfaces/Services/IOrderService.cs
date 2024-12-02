using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutShop.Domain.Entities;

namespace WorkoutShop.Application.ServiceInterfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId); // Додано

        Task<IEnumerable<Order>> GetAllOrdersAsync(string status = null);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> GetOrderByIdAsync(int orderId, string userId);

        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
    }
}
