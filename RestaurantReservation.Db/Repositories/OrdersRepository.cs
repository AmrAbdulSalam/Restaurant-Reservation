using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrdersRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public OrdersRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateOrder(Orders newOrder)
        {
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder.Id;
        }
        public async Task<Orders> GetOrder(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }
        public async Task DeleteOrder(int orderId)
        {
            var order = await GetOrder(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrder(Orders updateOrder)
        {
            _context.Orders.Update(updateOrder);
            await _context.SaveChangesAsync();
        }
    }
}