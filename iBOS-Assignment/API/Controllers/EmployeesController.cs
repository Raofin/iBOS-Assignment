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

        // PUT: api/Employees/UpdateNameAndCode/{employeeId}
        [HttpPut("UpdateNameAndCode/{id}")]
        public IActionResult UpdateNameAndCode(long id, [FromBody] EmpNameAndCodeDto employee)
        {
            EmployeeDto existingEmployee = _employeeService.Get(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update the EmployeeName and EmployeeCode properties
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

        // GET: api/Employees/GetEmployeesWithNoAbsentRecords
        [HttpGet("GetEmployeesWithNoAbsentRecords")]
        public IActionResult GetEmployeesWithNoAbsentRecords()
        {
            List<EmployeeDto> employeesWithNoAbsentRecords = _employeeService.GetEmployeesWithNoAbsentRecords();

            if (employeesWithNoAbsentRecords == null || employeesWithNoAbsentRecords.Count == 0)
            {
                return NotFound();
            }

            return Ok(employeesWithNoAbsentRecords);
        }

        // GET: api/Employees/GetHierarchy/{employeeId}
        [HttpGet("GetHierarchy/{employeeId}")]
        public IActionResult GetHierarchy(long employeeId)
        {
            List<EmployeeDto> hierarchy = _employeeService.GetHierarchyByEmployeeId(employeeId);

            if (hierarchy == null || hierarchy.Count == 0)
            {
                return NotFound();
            }

            return Ok(hierarchy);
        }
    }
}
