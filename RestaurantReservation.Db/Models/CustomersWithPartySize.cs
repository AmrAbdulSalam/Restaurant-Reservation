
namespace RestaurantReservation.Db.Models
{
    public class CustomersWithPartySize
    {
        public string? PartySize { get; set; }
        public string? FullName { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}