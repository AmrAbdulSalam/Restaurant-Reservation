
namespace RestaurantReservation.Db.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public int RestaurantsId { get; set; }
        public List<Orders> OrdersId { get; set; } = new List<Orders>();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
    }
}