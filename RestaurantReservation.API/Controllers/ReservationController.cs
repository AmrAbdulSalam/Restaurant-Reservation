using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService , IMapper mapper)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{reservationId}", Name = "GetReservationById")]
        public async Task<ActionResult<ReservationDTO>> GetReservationAsync(int reservationId)
        {
            var reservation = await _reservationService.GetReservationsAsync(reservationId);

            if (reservation == null)
            {
                return NotFound("No reservation found");
            }

            return Ok(_mapper.Map<ReservationDTO>(reservation));
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> CreateReservationAsync(ReservationForCreationDTO newReservation)
        {
            var newReservationId = await _reservationService.CreateReservationAsync(_mapper.Map<Reservations>(newReservation));

            var reservation = await _reservationService.GetReservationsAsync(newReservationId);

            return CreatedAtRoute("GetReservationById",
                new
                {
                    reservationId = newReservationId
                },
               _mapper.Map<ReservationDTO>(reservation));
        }

        [HttpDelete("{reservationId}")]
        public async Task<ActionResult> DeleteReservationAsync(int reservationId)
        {
            try
            {
                await _reservationService.DeleteReservationAsync(reservationId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("No reservation found");
            }
        }

        [HttpPut("{reservationId}")]
        public async Task<ActionResult> UpdateReservationAsync(int reservationId, ReservationDTO updatedReservation)
        {
            var reservation = _mapper.Map<Reservations>(updatedReservation);

            reservation.Id = reservationId;

            try
            {
                await _reservationService.UpdateReservationAsync(reservation);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("No reservation found");
            }
        }
    }
}