using iBOS_Assignment.BLL.Dtos;
using Microsoft.AspNetCore.Mvc;
using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using iBOS_Assignment.BLL.Interfaces;

namespace iBOS_Assignment.API.Controllers
{
    [Authorize]
    [Route("api/attendance")]
    [ApiController]
    public class EmployeeAttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public EmployeeAttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/attendance
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_attendanceService.Get());
        }

        // GET: api/attendance/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var attendance = _attendanceService.Get(id);

            return attendance == null 
                ? (IActionResult)NotFound("Employee Attendance not found.") 
                : Ok(attendance);
        }

        /*
        // POST: api/attendance
        [HttpPost]
        public IActionResult AddAttendance([FromBody] AttendanceDto attendance)
        {
            if (attendance == null)
                return BadRequest("Invalid attendance data");

            return _attendanceService.AddAttendance(attendance)
                ? (IActionResult)Ok("Attendance created successfully")
                : BadRequest("Attendance creation failed");
        }

        // PUT: api/attendance/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAttendance(long id, [FromBody] AttendanceDto attendance)
        {
            var existingAttendance = _attendanceService.Get(id);

            if (existingAttendance == null)
            {
                return NotFound("Employee Attendance not found.");
            }

            _attendanceService.UpdateAttendance(attendance);

            return Ok("Employee Attendance updated successfully.");
        }*/

        // DELETE: api/attendance/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAttendance(long id)
        {
            return _attendanceService.DeleteAttendance(id)
                ? Ok("Employee Attendance deleted successfully.")
                : (IActionResult)NotFound("Employee Attendance not found.");
        }
    }
}