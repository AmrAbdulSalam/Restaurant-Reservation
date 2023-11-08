
namespace RestaurantReservation.Db.Models
{
    public class Tables
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public List<Reservations> ReservationId { get; set; } = new List<Reservations>();
        public string? Capacity { get; set; }
    }
}