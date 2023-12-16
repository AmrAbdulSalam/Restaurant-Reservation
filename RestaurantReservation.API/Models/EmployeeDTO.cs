namespace RestaurantReservation.API.Models
{
    public class EmployeeDTO
    {
        public int RestaurantsId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Position { get; set; }
    }
}