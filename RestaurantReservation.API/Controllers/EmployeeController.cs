using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeAsync(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);

            if (employee == null)
            {
                return NotFound("No employee found");
            }

            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployeeAsync(EmployeeForCreationDTO newEmployee)
        {
            var newEmployeeId = await _employeeService.CreateEmployeeAsync(_mapper.Map<Employees>(newEmployee));

            var employee = await _employeeService.GetEmployeeAsync(newEmployeeId);

            return CreatedAtRoute("GetEmployeeById",
                new
                {
                    employeeId = newEmployeeId
                },
               _mapper.Map<EmployeeDTO>(employee));
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(employeeId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("No employee found");
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployeeAsync(int employeeId, EmployeeDTO updatedEmployee)
        {
            var employee = _mapper.Map<Employees>(updatedEmployee);

            employee.Id = employeeId;

            try
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("No employee found");
            }
        }
    }
}