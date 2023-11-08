using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantsRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public RestaurantsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateRestaurant(Restaurants newRestaurant)
        {
            await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return newRestaurant.Id;
        }
        public async Task<Restaurants> GetRestaurant(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }
        public async Task DeleteRestaurant(int restaurantId)
        {
            var restaurant = await GetRestaurant(restaurantId);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRestaurant(Restaurants updateRestaurant)
        {
            _context.Restaurants.Update(updateRestaurant);
            await _context.SaveChangesAsync();
        }
    }
}