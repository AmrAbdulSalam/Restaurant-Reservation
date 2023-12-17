using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService , IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{customerId}" , Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerDTO>> GetCustomersAsync(int customerId)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync(CustomerForCreationDTO newCustomer)
        {
            var newCustomerId = await _customerService.CreateCustomerAsync(_mapper.Map<Customers>(newCustomer));

            var customer = await _customerService.GetCustomerAsync(newCustomerId);

            return CreatedAtRoute("GetCustomerById",
                new
                {
                    customerId = newCustomerId
                },
               _mapper.Map<CustomerDTO>(customer));
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomerAsync(int customerId , CustomerDTO updatedCustomer)
        {
            var customer = _mapper.Map<Customers>(updatedCustomer);

            customer.Id = customerId;

            try
            {
                await _customerService.UpdateCustomerAsync(customer);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}