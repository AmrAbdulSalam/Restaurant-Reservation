using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Check if user is in the database
        /// </summary>
        /// <param name="user">The user object</param>
        /// <returns>Bool value if the user exists or not</returns>
        Task<bool> UserExistsAsync(User user);
    }
}