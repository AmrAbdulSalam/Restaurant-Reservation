using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderItemAsync(OrderItems newOrderItem)
        {
            if (newOrderItem == null)
            {
                throw new ArgumentNullException(nameof(newOrderItem));
            }
            await _context.OrderItems.AddAsync(newOrderItem);
            await _context.SaveChangesAsync();
            return newOrderItem.Id;
        }

        public async Task<OrderItems> GetOrderItemAsync(int orderItemId)
        {
            return await _context.OrderItems.FindAsync(orderItemId);
        }

        public async Task DeleteOrderItemAsync(int orderItemTable)
        {
            var orderItem = await GetOrderItemAsync(orderItemTable);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItems updateOrderItem)
        {
            if (await GetOrderItemAsync(updateOrderItem.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateOrderItem));
            }
            _context.OrderItems.Update(updateOrderItem);
            await _context.SaveChangesAsync();
        }
    }
}