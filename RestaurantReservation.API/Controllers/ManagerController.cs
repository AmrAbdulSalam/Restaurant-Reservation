using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/employees/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public ManagerController(IEmployeeService employeeService , IMapper mapper)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> ListManagersAsync()
        {
            var managersList = await _employeeService.ListManagersAsync();

            return Ok(_mapper.Map<List<EmployeeDTO>>(managersList));
        }
    }
}