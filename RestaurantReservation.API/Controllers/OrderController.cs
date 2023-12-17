﻿using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(List<Orders>))]
        public async Task<ActionResult<List<Orders>>> GetOrderList(int reservationId)
        {
            var reservationExists = await _reservationService.ResevationExists(reservationId);

            if (!reservationExists) 
            {
                return NotFound("No reservation found");
            }

            return Ok(await _reservationService.ListOrdersAndMenuItemsAsync(reservationId));
        }

        [HttpGet("menu-items")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MenuItems>))]
        public async Task<ActionResult<List<MenuItems>>> GetMenuItemList(int reservationId)
        {
            var reservationExists = await _reservationService.ResevationExists(reservationId);

            if (!reservationExists)
            {
                return NotFound("No reservation found");
            }

            return Ok(await _reservationService.ListOrderedMenuItemsAsync(reservationId));
        }
    }
}