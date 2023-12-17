using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Authenticate;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJWTTokenServices _tokenService;

        public UserController(IUserService userService , IMapper mapper , IJWTTokenServices tokenService)
        {
            _userService = userService;
            _mapper= mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<JWTTokensDTO>> CheckUser(UserDTO user)
        {
            var newUser = _mapper.Map<User>(user);

            var userExists = await _userService.UserExistsAsync(newUser);

            if (!userExists)
            {
                return NotFound();
            }

            var token = _tokenService.Authenticate(newUser);

            return Ok(token);
        }
    }
}