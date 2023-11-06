
namespace RestaurantReservation.Db.Models
{
    public class Tables
    {
        public int Id { get; set; }
        public List<Restaurants> RestaurantId { get; set; } = new List<Restaurants>();
        public string? Capacity { get; set; }
    }
}