using iBOS_Assignment.BLL.Dtos;
using iBOS_Assignment.BLL.Interfaces;
using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iBOS_Assignment.API.Controllers
{
    [Authorize]
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.Get();

            return employees == null || employees.Count == 0
                ? (IActionResult)NotFound("No employees found.")
                : Ok(employees);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var employee = _employeeService.Get(id);

            return employee == null
                ? (IActionResult)NotFound("Employee not found.")
                : Ok(employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] EmployeeDto employee)
        {
            var existingEmployee = _employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound("Employee not found.");
            }

            // Update only the properties that are provided in the request
            if (employee.EmployeeName != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
            }

            // Convert the EmployeeCode to uppercase.
            employee.EmployeeCode = employee.EmployeeCode.ToUpper();

            if (employee.EmployeeCode != null)
            {

                // Check if the new EmployeeCode already exists.
                if (_employeeService.EmployeeCodeExists(employee.EmployeeCode))
                {
                    return BadRequest("EmployeeCode must be unique");
                }

                existingEmployee.EmployeeCode = employee.EmployeeCode;
            }

            if (employee.EmployeeSalary != default(int))
            {
                existingEmployee.EmployeeSalary = employee.EmployeeSalary;
            }

            if (employee.SupervisorId.HasValue)
            {
                existingEmployee.SupervisorId = employee.SupervisorId;
            }

            return _employeeService.Update(existingEmployee)
                ? (IActionResult)Ok("Employee updated successfully")
                : BadRequest("Employee update failed");
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingEmployee = _employeeService.Get(id);

            if (existingEmployee == null)
                return NotFound("Employee not found.");

            return _employeeService.Delete(id)
                ? (IActionResult)Ok("Employee deleted successfully")
                : BadRequest("Failed to delete employee");
        }

        // POST: api/employees
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data");
            }

            // Convert the EmployeeCode to uppercase.
            employee.EmployeeCode = employee.EmployeeCode.ToUpper();

            // Check if the new EmployeeCode already exists.
            if (_employeeService.EmployeeCodeExists(employee.EmployeeCode))
            {
                return BadRequest("EmployeeCode must be unique");
            }

            return _employeeService.Create(employee)
                ? (IActionResult)Ok("Employee created successfully")
                : BadRequest("Employee creation failed");
        }

        // GET: api/employees/exists/{id}
        [HttpGet("Exists/{id}")]
        public IActionResult Exists(long id)
        {
            var exists = _employeeService.Exists(id);

            return Ok(exists ? "Employee exists" : "Employee does not exist");
        }
    }
}
