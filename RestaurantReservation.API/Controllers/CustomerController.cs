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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(CustomerDTO))]
        public async Task<ActionResult<CustomerDTO>> GetCustomersAsync(int customerId)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);

            if (customer == null)
            {
                return NotFound("No customer found");
            }

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("No customer found");
            }
        }

        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound("No customer found");
            }
        }
    }
}