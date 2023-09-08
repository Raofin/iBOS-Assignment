using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("ID mismatch");
            }

            var updatedEmployee = _employeeService.Update(employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deletedEmployee = _employeeService.Delete(id);

            if (deletedEmployee == null)
            {
                return NotFound();
            }

            return Ok(deletedEmployee);
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
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
