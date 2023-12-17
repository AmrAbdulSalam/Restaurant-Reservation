using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public CustomerRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomerAsync(Customers newCustomer)
        {
            if (newCustomer == null)
            {
                throw new ArgumentNullException(nameof(newCustomer));
            }
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await GetCustomerAsync(customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customers> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return customer;
        }

        public async Task UpdateCustomerAsync(Customers updatedCustomer)
        {
            if (!await CustomerExists(updatedCustomer.Id))
            {
                throw new ArgumentNullException(nameof(updatedCustomer));
            }
            _context.Customers.Update(updatedCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customers>> CustomersWithSpecificReservationPartySize(string partySize)
        {
            var customers = await _context.Customers.FromSqlRaw($"EXEC dbo.ReservationWithSpecificPartySize '{partySize}'").ToListAsync();
            return customers;
        }

        public async Task<bool> CustomerExists(int customerId)
        {
            return await _context.Customers.AnyAsync(customer => customer.Id == customerId);
        }
    }
}