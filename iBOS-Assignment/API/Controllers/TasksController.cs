using iBOS_Assignment.BLL.Dtos;
using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace iBOS_Assignment.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly AttendanceService _attendanceService;

        public TasksController(EmployeeService employeeService, AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService;
        }

        // PUT: api/Employees/UpdateNameAndCode/{employeeId}
        [HttpPut("UpdateNameAndCode/{employeeId}")]
        public IActionResult UpdateNameAndCode(long employeeId, [FromBody] EmpNameAndCodeDto employee)
        {
            EmployeeDto existingEmployee = _employeeService.Get(employeeId);

            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
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

            return Ok("Employee updated successfully");
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
        [HttpGet("GetEmployeesMaxToMinSalaryWithNoAbsent")]
        public IActionResult GetEmployeesWithNoAbsentRecords()
        {
            List<EmployeeDto> employeesWithNoAbsentRecords = _employeeService.GetEmployeesWithNoAbsentRecords();

            if (employeesWithNoAbsentRecords == null || employeesWithNoAbsentRecords.Count == 0)
            {
                return NotFound();
            }

            return Ok(employeesWithNoAbsentRecords);
        }

        // GET: api/Attendance/MonthlyReport?year=2023&month=9
        [HttpGet("MonthlyAttendanceReport")]
        public IActionResult GetMonthlyAttendanceReport(int year, int month)
        {
            var reportData = _attendanceService.CalculateMonthlyReport(year, month);

            return Ok(reportData);
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
