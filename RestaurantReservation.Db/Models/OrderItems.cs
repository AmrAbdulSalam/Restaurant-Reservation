
namespace RestaurantReservation.Db.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public List<Orders> OrderId { get; set; } = new List<Orders>(); 
        public List<MenuItems> ItemId { get; set; } = new List<MenuItems>();
        public int Quantity { get; set; }
    }
}