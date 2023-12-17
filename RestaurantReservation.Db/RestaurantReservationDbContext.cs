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
        public DbSet<ReservationsWithCustomerAndRestaurantInfo> View_ReservationsWithCustomerAndRestaurantInfo { get; set; }
        public DbSet<EmployeesWithRespectiveRestaurant> View_EmployeesWithRespectiveRestaurant { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NUK8KNC\\SQLEXPRESS;Initial Catalog=RestaurantReservationCore;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationsWithCustomerAndRestaurantInfo>().HasNoKey().ToView("View_ReservationsWithCustomerAndRestaurantInfo");
            modelBuilder.Entity<EmployeesWithRespectiveRestaurant>().HasNoKey().ToView("View_EmployeesWithRespectiveRestaurant");
        }
    }
}