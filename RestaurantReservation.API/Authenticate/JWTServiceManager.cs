using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Authenticate
{
    public class JWTServiceManager : IJWTTokenServices
    {
        private readonly IConfiguration _configuration;

        public JWTServiceManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JWTTokensDTO Authenticate(User user)
        {
            var tokenHandle = new JwtSecurityTokenHandler();

            var tKey = Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name , user.Username));

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey (tKey) ,SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandle.CreateToken(tokenDescription);

            return new JWTTokensDTO { Token = tokenHandle.WriteToken(token) };
        }
    }
}