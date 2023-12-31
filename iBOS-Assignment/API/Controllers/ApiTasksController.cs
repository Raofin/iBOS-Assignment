﻿using iBOS_Assignment.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iBOS_Assignment.BLL.Dtos;
using System;

namespace iBOS_Assignment.API.Controllers
{
    [Authorize] // Specify that authorization is required to access this controller.
    [ApiController]
    [Route("api/tasks")]
    public class ApiTasksController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAttendanceService _attendanceService;

        public ApiTasksController(IEmployeeService employeeService, IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService;
        }

        // PUT: api/Employees/UpdateNameAndCode/{employeeId}
        [HttpPut("UpdateNameAndCode/{employeeId}")]
        public IActionResult UpdateNameAndCode(long employeeId, [FromBody] EmpNameAndCodeDto employee)
        {
            var existingEmployee = _employeeService.Get(employeeId);

            if (existingEmployee == null)
            {
                return NotFound("Employee not found"); // Return a 404 Not Found response if the employee doesn't exist.
            }

            if (!string.IsNullOrEmpty(employee.EmployeeCode))
            {
                // Check if the new EmployeeCode already exists.
                if (_employeeService.EmployeeCodeExists(employee.EmployeeCode))
                {
                    return BadRequest("EmployeeCode must be unique"); // Return a 400 Bad Request response.
                }

                // Update the EmployeeCode property.
                existingEmployee.EmployeeCode = employee.EmployeeCode;
            }

            if (!string.IsNullOrEmpty(employee.EmployeeName))
            {
                // Update the EmployeeName property.
                existingEmployee.EmployeeName = employee.EmployeeName;
            }

            // Update the employee in the database.
            _employeeService.Update(existingEmployee);

            return Ok("Employee updated successfully"); // Return a 200 OK response after updating the employee.
        }

        // GET: api/Employees/GetThirdHighestSalaryEmployee
        [HttpGet("GetThirdHighestSalaryEmployee")]
        public IActionResult GetThirdHighestSalaryEmployee()
        {
            // Retrieve the employee with the third highest salary.
            var thirdHighestSalaryEmployee = _employeeService.GetThirdHighestSalaryEmployee();

            if (thirdHighestSalaryEmployee == null)
            {
                return NotFound("No employee with the 3rd highest salary found.");
            }

            return Ok(thirdHighestSalaryEmployee);
        }

        // GET: api/Employees/GetEmployeesWithNoAbsentRecords
        [HttpGet("GetEmployeesMaxToMinSalaryWithNoAbsent")]
        public IActionResult GetEmployeesWithNoAbsentRecords()
        {
            // Retrieve employees with no absent records ordered by salary from max to min.
            var employeesWithNoAbsentRecords = _employeeService.GetEmployeesWithNoAbsentRecords();

            if (employeesWithNoAbsentRecords == null || employeesWithNoAbsentRecords.Count == 0)
            {
                return NotFound("No employees found.");
            }

            return Ok(employeesWithNoAbsentRecords);
        }

        // GET: api/Attendance/MonthlyReport?year={year}&month={month}
        [HttpGet("MonthlyAttendanceReport")]
        public IActionResult GetMonthlyAttendanceReport(int year, int month)
        {
            // Validate the year and month.
            if (year < 1 || year > DateTime.Now.Year || month < 1 || month > 12)
                return BadRequest("Invalid year or month.");

            // Calculate the monthly attendance report for the specified year and month.
            var reportData = _attendanceService.CalculateMonthlyReport(year, month);

            return reportData == null
                ? (IActionResult)NotFound("No data matched with the given year and month.")
                : Ok(reportData);
        }

        // GET: api/Employees/GetHierarchy/{employeeId}
        [HttpGet("GetHierarchy/{employeeId}")]
        public IActionResult GetHierarchy(long employeeId)
        {
            // Retrieve the hierarchy of employees based on the specified employeeId.
            var hierarchy = _employeeService.GetHierarchyByEmployeeId(employeeId);

            if (hierarchy == null || hierarchy.Count == 0)
                return NotFound("No employees found.");

            return Ok(hierarchy);
        }
    }
}
