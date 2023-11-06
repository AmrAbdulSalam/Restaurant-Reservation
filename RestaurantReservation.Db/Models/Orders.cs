
namespace RestaurantReservation.Db.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public List<Reservations> ReservationId { get; set; } = new List<Reservations>();
        public List<Employees> EmployeeId { get; set; } = new List<Employees>();
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
    }
}