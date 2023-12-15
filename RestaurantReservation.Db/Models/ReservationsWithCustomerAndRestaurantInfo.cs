
namespace RestaurantReservation.Db.Models
{
    public class ReservationsWithCustomerAndRestaurantInfo
    {
        public string? PartySize { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? FullName { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? OpeningHours { get; set; }
    }
}