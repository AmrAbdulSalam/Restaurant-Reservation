using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public interface IRestaurantRepository
    {
        Task<int> CreateRestaurantAsync(Restaurants newRestaurant);
        Task DeleteRestaurantAsync(int restaurantId);
        Task<Restaurants> GetRestaurantAsync(int restaurantId);
        Task UpdateRestaurantAsync(Restaurants updateRestaurant);
    }
}