
namespace RestaurantReservation.Db.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public List<Restaurants> RestaurantId { get; set; } = new List<Restaurants>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
    }
}