using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/reservations/{reservationId}")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public OrderController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<List<Orders>>> GetOrderList(int reservationId)
        {
            var reservationExists = await _reservationService.ResevationExists(reservationId);

            if (!reservationExists) 
            {
                return NotFound();
            }

            return Ok(await _reservationService.ListOrdersAndMenuItemsAsync(reservationId));
        }

        [HttpGet("menu-items")]
        public async Task<ActionResult<List<MenuItems>>> GetMenuItemList(int reservationId)
        {
            var reservationExists = await _reservationService.ResevationExists(reservationId);

            if (!reservationExists)
            {
                return NotFound();
            }

            return Ok(await _reservationService.ListOrderedMenuItemsAsync(reservationId));
        }
    }
}