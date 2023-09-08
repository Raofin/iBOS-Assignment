using iBOS_Assignment.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iBOS_Assignment.API.Controllers
{
    // AttendanceController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/Attendance/MonthlyReport?year=2023&month=9
        [HttpGet("MonthlyReport")]
        public IActionResult GetMonthlyAttendanceReport(int year, int month)
        {
            var reportData = _attendanceService.CalculateMonthlyReport(year, month);

            return Ok(reportData);
        }
    }
}
