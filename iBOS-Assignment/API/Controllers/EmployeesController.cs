using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBOS_Assignment.BLL.Dtos;
using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iBOS_Assignment.DAL;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        // PUT: api/Employees/UpdateNameAndCode/5
        [HttpPut("UpdateNameAndCode/{id}")]
        public IActionResult UpdateNameAndCode(long id, [FromBody] EmpNameAndCodeDto employee)
        {
            EmployeeDto existingEmployee = _employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update only the EmployeeName and EmployeeCode properties
            if (!string.IsNullOrEmpty(employee.EmployeeName))
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
            }

            if (!string.IsNullOrEmpty(employee.EmployeeCode))
            {
                existingEmployee.EmployeeCode = employee.EmployeeCode;
            }

            var updatedEmployee = _employeeService.Update(existingEmployee);

            return Ok(updatedEmployee);
        }

        // GET: api/Employees/GetThirdHighestSalaryEmployee
        [HttpGet("GetThirdHighestSalaryEmployee")]
        public IActionResult GetThirdHighestSalaryEmployee()
        {
            EmployeeDto thirdHighestSalaryEmployee = _employeeService.GetThirdHighestSalaryEmployee();

            if (thirdHighestSalaryEmployee == null)
            {
                return NotFound("No employee with the 3rd highest salary found.");
            }

            return Ok(thirdHighestSalaryEmployee);
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult Get()
        {
            var employee = _employeeService.Get();

            return Ok(employee);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var employee = _employeeService.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] EmployeeDto employee)
        {
            EmployeeDto existingEmployee = _employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update only the properties that are provided in the request
            if (employee.EmployeeName != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
            }

            if (employee.EmployeeCode != null)
            {
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

            var updatedEmployee = _employeeService.Update(existingEmployee);

            return Ok(updatedEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingEmployee = _employeeService.Get(id);

            return existingEmployee == null 
                ? (IActionResult)NotFound() 
                : Ok(_employeeService.Delete(id));
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data");
            }

            var creationSuccess = _employeeService.Create(employee);

            if (creationSuccess)
            {
                return Ok("Employee created successfully");
            }
            else
            {
                return BadRequest("Employee creation failed");
            }
        }

        // GET: api/Employees/Exists/5
        [HttpGet("Exists/{id}")]
        public IActionResult Exists(long id)
        {
            var exists = _employeeService.Exists(id);

            return Ok(exists);
        }
    }
}
