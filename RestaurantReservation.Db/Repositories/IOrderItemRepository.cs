using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderItemRepository
    {
        Task<int> CreateOrderItemAsync(OrderItems newOrderItem);
        Task DeleteOrderItemAsync(int orderItemTable);
        Task<OrderItems> GetOrderItemAsync(int orderItemId);
        Task UpdateOrderItemAsync(OrderItems updateOrderItem);
    }
}