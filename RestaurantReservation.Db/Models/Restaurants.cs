
namespace RestaurantReservation.Db.Models
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OpeningHours { get; set; }
        public List<Employees> EmployeesId { get; set; } = new List<Employees>();
        public List<MenuItems> MenuItemsId { get; set; } = new List<MenuItems>();
        public List<Tables> TablesId { get; set; } = new List<Tables>();
        public List<Reservations> ReservationsId { get; set; } = new List<Reservations>();
    }
}