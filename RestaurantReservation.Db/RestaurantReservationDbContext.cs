using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NUK8KNC\\SQLEXPRESS;Initial Catalog=RestaurantReservationCore;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}