using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly RestaurantReservationDbContext _context;

        public UserService(RestaurantReservationDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        public async Task<bool> UserExistsAsync(User user)
        {
            return await _userRepository.UserExists(user);
        }
    }
}