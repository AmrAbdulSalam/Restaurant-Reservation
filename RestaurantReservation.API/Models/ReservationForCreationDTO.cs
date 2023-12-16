using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class ReservationForCreationDTO
    {
        [Required]
        public int CustomersId { get; set; }

        [Required]
        public int RestaurantsId { get; set; }

        [Required]
        public int TablesId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string? PartySize { get; set; }
    }
}