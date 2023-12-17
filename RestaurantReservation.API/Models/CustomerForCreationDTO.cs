using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class CustomerForCreationDTO
    {
        [Required]
        [MaxLength(10)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}