using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;
        public RestaurantService(RestaurantRepository restaurantRepository) 
        {
            _restaurantRepository = restaurantRepository;
        }

        public int CalculateTotalRevenure(int restaurantId)
        {
            return _restaurantRepository.CalculateTotalRevenure(restaurantId);
        }
    }
}