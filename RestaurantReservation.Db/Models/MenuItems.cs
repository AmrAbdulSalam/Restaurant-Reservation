
namespace RestaurantReservation.Db.Models
{
    public class MenuItems
    {
        public int Id { get; set; }
        public List<OrderItems> OrderItemsId { get; set; } = new List<OrderItems>();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}