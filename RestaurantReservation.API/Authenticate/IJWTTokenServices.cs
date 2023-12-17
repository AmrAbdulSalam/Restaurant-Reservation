using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Authenticate
{
    public interface IJWTTokenServices
    {
        JWTTokensDTO Authenticate(User user);
    }
}