
namespace RestaurantReservation.Db.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public List<OrderItems> OrderItemsId { get; set; } = new List<OrderItems>();
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}