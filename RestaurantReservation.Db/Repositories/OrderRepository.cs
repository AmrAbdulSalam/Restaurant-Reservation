using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderAsync(Orders newOrder)
        {
            if (newOrder == null)
            {
                throw new ArgumentNullException(nameof(newOrder));
            }
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder.Id;
        }

        public async Task<Orders> GetOrderAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await GetOrderAsync(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Orders updateOrder)
        {
            if (await GetOrderAsync(updateOrder.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateOrder));
            }
            _context.Orders.Update(updateOrder);
            await _context.SaveChangesAsync();
        }
    }
}