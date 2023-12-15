using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IRestaurantRepository
    {
        /// <summary>
        /// Create a new Restaurant
        /// </summary>
        /// <param name="newRestaurant">The created Restaurant entity</param>
        /// <returns>The new Restaurant Id</returns>
        Task<int> CreateRestaurantAsync(Restaurants newRestaurant);

        /// <summary>
        /// Delete an existing Restaurant
        /// </summary>
        /// <param name="restaurantId">Passing restaurant Id</param>
        Task DeleteRestaurantAsync(int restaurantId);

        /// <summary>
        /// Get an existing Restaurant
        /// </summary>
        /// <param name="restaurantId">Passing restaurant Id</param>
        /// <returns>Restaurant object</returns>
        Task<Restaurants> GetRestaurantAsync(int restaurantId);

        /// <summary>
        /// Update an existing Restaurant
        /// </summary>
        /// <param name="updateRestaurant">Restaurant entity</param>
        Task UpdateRestaurantAsync(Restaurants updateRestaurant);
    }
}