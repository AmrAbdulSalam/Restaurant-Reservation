using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRestaurantAsync(Restaurants newRestaurant)
        {
            if (newRestaurant == null)
            {
                throw new ArgumentNullException(nameof(newRestaurant));
            }
            await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return newRestaurant.Id;
        }

        public async Task<Restaurants> GetRestaurantAsync(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await GetRestaurantAsync(restaurantId);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurants updateRestaurant)
        {
            if (await GetRestaurantAsync(updateRestaurant.Id) == null)
            {
                throw new ArgumentNullException(nameof(updateRestaurant));
            }
            _context.Restaurants.Update(updateRestaurant);
            await _context.SaveChangesAsync();
        }

        public int CalculateTotalRevenure(int restaurantId)
        {
            var result = _context.Database.SqlQuery<int>($"SELECT dbo.TotalRevenuBySpecificRestaurant({restaurantId})").ToList().FirstOrDefault();
            return result;
        }
    }
}