using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantService
    {
        private readonly RestaurantReservationDbContext _context;
        public RestaurantService(RestaurantReservationDbContext context) 
        {
            _context = context;
        }

        public int CalculateTotalRevenure(int restaurantId)
        {
            var result =  _context.Database.SqlQuery<int>($"SELECT dbo.TotalRevenuBySpecificRestaurant({restaurantId})").ToList().FirstOrDefault();
            return result;
        }
    }
}