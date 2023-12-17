using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [Route("api/employees/{employeeId}")]
    [ApiController]
    public class EmployeeOrdersController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeOrdersController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("average-order-amount")]
        public ActionResult<double> CalculateAverageOrderAmount(int employeeId)
        {
            return Ok(_employeeService.CalculateAverageOrderAmount(employeeId));
        }
    }
}