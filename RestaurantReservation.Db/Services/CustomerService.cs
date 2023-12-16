using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class CustomerService
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
    }
}