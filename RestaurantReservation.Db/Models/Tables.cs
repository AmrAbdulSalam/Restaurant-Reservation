
namespace RestaurantReservation.Db.Models
{
    public class Tables
    {
        public int Id { get; set; }
        public int RestaurantsId { get; set; }
        public List<Reservations> ReservationsId { get; set; } = new List<Reservations>();
        public string? Capacity { get; set; }
    }
}