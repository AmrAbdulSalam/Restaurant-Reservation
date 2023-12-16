using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly RestaurantReservationDbContext _dbContext;

        public RestaurantService(RestaurantReservationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _restaurantRepository = new RestaurantRepository(_dbContext);
        }

        public int CalculateTotalRevenure(int restaurantId)
        {
            return _restaurantRepository.CalculateTotalRevenure(restaurantId);
        }
    }
}