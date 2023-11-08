using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemsRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public OrderItemsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateOrderItem(OrderItems newOrderItem)
        {
            await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();
            return newOrderItem.Id;
        }
        public async Task<OrderItems> GetOrderItem(int orderItemId)
        {
            return await _context.OrderItems.FindAsync(orderItemId);
        }
        public async Task DeleteOrderItem(int orderItemTable)
        {
            var orderItem = await GetOrderItem(orderItemTable);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderItem(OrderItems updateOrderItem)
        {
            _context.OrderItems.Update(updateOrderItem);
            await _context.SaveChangesAsync();
        }
    }
}