
namespace RestaurantReservation.Db.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Reservations> ReservationsId { get; set; } = new List<Reservations>();
    }
}