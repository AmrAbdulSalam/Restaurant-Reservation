using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customers>> CustomersWithSpecificReservationPartySize(string partySize)
        {
            return await _customerRepository.CustomersWithSpecificReservationPartySize(partySize);
        }

        public async Task<int> CreateCustomerAsync(Customers newCustomer)
        {
            return await _customerRepository.CreateCustomerAsync(newCustomer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<Customers> GetCustomerAsync(int customerId)
        {
            return await _customerRepository.GetCustomerAsync(customerId);
        }

        public async Task UpdateCustomerAsync(Customers updatedCustomer)
        {
            await _customerRepository.UpdateCustomerAsync(updatedCustomer);
        }
    }
}