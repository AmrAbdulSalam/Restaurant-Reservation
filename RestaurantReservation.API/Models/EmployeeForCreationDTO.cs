using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.API.Models
{
    public class EmployeeForCreationDTO
    {
        [Required]
        public int RestaurantsId { get; set; }

        [Required]
        [MaxLength(10)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Position { get; set; }
    }
}