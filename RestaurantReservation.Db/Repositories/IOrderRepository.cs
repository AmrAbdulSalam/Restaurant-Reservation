using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(Orders newOrder);
        Task DeleteOrderAsync(int orderId);
        Task<Orders> GetOrderAsync(int orderId);
        Task UpdateOrderAsync(Orders updateOrder);
    }
}