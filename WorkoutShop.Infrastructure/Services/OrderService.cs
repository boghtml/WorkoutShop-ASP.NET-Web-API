using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WorkoutShop.Application.ServiceInterfaces;
using WorkoutShop.Application.RepositorieInterfaces;

namespace WorkoutShop.Infrastructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IShoppingCartService _cartService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IShoppingCartService cartService, IOrderRepository orderRepository)
        {
            _cartService = cartService;
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(string userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart != null && cart.CartItems.Any())
            {
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.UtcNow, // Використовуємо DateTime.UtcNow
                    Status = "Pending",
                    TotalPrice = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                    CreatedAt = DateTime.UtcNow,
                    OrderItems = cart.CartItems.Select(ci => new OrderItem
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        Price = ci.Product.Price,
                        CreatedAt = DateTime.UtcNow
                    }).ToList()
                };

                await _orderRepository.AddOrderAsync(order);

                // Очистити кошик після створення замовлення
                cart.CartItems.Clear();
                await _cartService.SaveChangesAsync();

                await _orderRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(string status)
        {
            return await _orderRepository.GetAllOrdersAsync(status);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId, string userId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId, userId);
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return false;
            }
            order.Status = status;
            await _orderRepository.SaveChangesAsync();
            return true;
        }
    }
}
