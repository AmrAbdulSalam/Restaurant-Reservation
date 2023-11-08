
namespace RestaurantReservation.Db.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int MenuItemsId { get; set; }
        public MenuItems? MenuItems { get; set; }
        public int Quantity { get; set; }
    }
}