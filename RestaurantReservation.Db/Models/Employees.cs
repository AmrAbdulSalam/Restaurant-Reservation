
namespace RestaurantReservation.Db.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public List<Orders> OrderId { get; set; } = new List<Orders>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
    }
}