using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IOrderItemRepository
    {
        /// <summary>
        /// Create a new Order Item
        /// </summary>
        /// <param name="newOrderItem">The created Order Item entity</param>
        /// <returns>The new Order Item Id</returns>
        Task<int> CreateOrderItemAsync(OrderItems newOrderItem);

        /// <summary>
        /// Delete an existing Order item
        /// </summary>
        /// <param name="orderItemTable">Passing an existing order item Id</param>
        Task DeleteOrderItemAsync(int orderItemTable);

        /// <summary>
        /// Get an existing Order Item
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns>Order Item object</returns>
        Task<OrderItems> GetOrderItemAsync(int orderItemId);

        /// <summary>
        /// Update an existing Order Item
        /// </summary>
        /// <param name="updateOrderItem">The created Menu Item entity</param>
        Task UpdateOrderItemAsync(OrderItems updateOrderItem);
    }
}