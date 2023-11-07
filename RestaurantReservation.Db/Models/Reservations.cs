﻿
namespace RestaurantReservation.Db.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public List<Orders> OrderId { get; set; } = new List<Orders>();
        public DateTime ReservationDate { get; set; }
        public string? PartySize { get; set; }
    }
}