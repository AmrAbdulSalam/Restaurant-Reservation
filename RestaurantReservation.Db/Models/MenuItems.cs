
namespace RestaurantReservation.Db.Models
{
    public class MenuItems
    {
        public int Id { get; set; }
        public List<Restaurants> RestaurantId { get; set; } = new List<Restaurants>();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}