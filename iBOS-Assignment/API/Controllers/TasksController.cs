using iBOS_Assignment.BLL.Interfaces;
using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iBOS_Assignment.API.Dtos;

namespace iBOS_Assignment.API.Controllers
{
    [Authorize] // Specify that authorization is required to access this controller.
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAttendanceService _attendanceService;

        public TasksController(IEmployeeService employeeService, IAttendanceService attendanceService)
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

            // Update the EmployeeName and EmployeeCode properties
            if (!string.IsNullOrEmpty(employee.EmployeeName))
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
            }

            if (!string.IsNullOrEmpty(employee.EmployeeCode))
            {
                existingEmployee.EmployeeCode = employee.EmployeeCode;
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
                return NotFound();
            }

            return Ok(employeesWithNoAbsentRecords);
        }

        // GET: api/Attendance/MonthlyReport?year=2023&month=9
        [HttpGet("MonthlyAttendanceReport")]
        public IActionResult GetMonthlyAttendanceReport(int year, int month)
        {
            // Calculate the monthly attendance report for the specified year and month.
            var reportData = _attendanceService.CalculateMonthlyReport(year, month);

            return Ok(reportData);
        }

        // GET: api/Employees/GetHierarchy/{employeeId}
        [HttpGet("GetHierarchy/{employeeId}")]
        public IActionResult GetHierarchy(long employeeId)
        {
            // Retrieve the hierarchy of employees based on the specified employeeId.
            var hierarchy = _employeeService.GetHierarchyByEmployeeId(employeeId);

            if (hierarchy == null || hierarchy.Count == 0)
            {
                return NotFound();
            }

            return Ok(hierarchy);
        }
    }
}
