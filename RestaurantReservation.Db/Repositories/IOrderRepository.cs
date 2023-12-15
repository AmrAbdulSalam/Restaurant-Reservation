using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="newOrder">The created Order Entity</param>
        /// <returns>The new Order Id</returns>
        Task<int> CreateOrderAsync(Orders newOrder);

        /// <summary>
        /// Delete an existing Order
        /// </summary>
        /// <param name="orderId">Passing existing order Id</param>
        Task DeleteOrderAsync(int orderId);

        /// <summary>
        /// Get an existing Order
        /// </summary>
        /// <param name="orderId">Passing existing order Id</param>
        /// <returns>Order object</returns>
        Task<Orders> GetOrderAsync(int orderId);

        /// <summary>
        /// Update an existing Order
        /// </summary>
        /// <param name="updateOrder">Passing an existng Order</param>
        Task UpdateOrderAsync(Orders updateOrder);
    }
}