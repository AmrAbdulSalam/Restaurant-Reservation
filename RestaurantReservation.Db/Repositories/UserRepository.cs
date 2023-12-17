using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantReservationDbContext _contex;

        public UserRepository(RestaurantReservationDbContext context)
        {
            _contex = context;
        }

        public async Task<bool> UserExists(User user)
        {
            return await _contex.User.AnyAsync(x => x.Username == user.Username && x.Password == user.Password);
        }
    }
}