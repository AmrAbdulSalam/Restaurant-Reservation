using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService
    {
        private readonly RestaurantReservationDbContext _context;
        public CustomerService(RestaurantReservationDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Customers>> CustomersWithSpecificReservationPartySize(string partySize)
        {
            var customers =  await _context.Customers.FromSqlRaw($"EXEC dbo.ReservationWithSpecificPartySize '{partySize}'").ToListAsync();
            return customers;
        }
    }
}