﻿
namespace RestaurantReservation.Db.Models
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OpeningHours { get; set; }
    }
}