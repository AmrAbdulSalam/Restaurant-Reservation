
namespace RestaurantReservation.Db.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public List<Customers> CustomerId { get; set; } = new List<Customers>();
        public List<Restaurants> RestaurantId { get; set; } = new List<Restaurants>();
        public List<Tables> TableId { get; set; } = new List<Tables>();
        public DateTime ReservationDate { get; set; }
        public string? PartySize { get; set; }
    }
}