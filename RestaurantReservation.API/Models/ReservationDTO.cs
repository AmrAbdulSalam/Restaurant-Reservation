namespace RestaurantReservation.API.Models
{
    public class ReservationDTO
    {
        public int CustomersId { get; set; }

        public int RestaurantsId { get; set; }

        public int TablesId { get; set; }

        public DateTime ReservationDate { get; set; }

        public string? PartySize { get; set; }
    }
}