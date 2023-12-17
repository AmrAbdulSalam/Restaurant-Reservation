using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/reservations/customer")]
    [ApiController]
    public class CustomerReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerReservationsController(IReservationService reservationService, IMapper mapper, ICustomerService customerService)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(List<ReservationDTO>))]
        public async Task<ActionResult<List<ReservationDTO>>> GetCustomerReservationsAsync(int customerId)
        {
            var customerExists = await _customerService.CustomerExists(customerId);

            if (!customerExists)
            {
                return NotFound("No customer found");
            }

            var reservations = await _reservationService.GetReservationsByCustomerAsync(customerId);

            return Ok(_mapper.Map<List<ReservationDTO>>(reservations));
        }
    }
}