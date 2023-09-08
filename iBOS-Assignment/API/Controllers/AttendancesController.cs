using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iBOS_Assignment.BLL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iBOS_Assignment.DAL;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.BLL.Services;

namespace iBOS_Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendancesController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: api/Attendance
        [HttpGet]
        public IActionResult Get()
        {
            var attendances = _attendanceService.Get();
            return Ok(attendances);
        }

        // GET: api/Attendance/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var attendance = _attendanceService.Get(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        // POST: api/Attendance
        [HttpPost]
        public IActionResult AddAttendance([FromBody] AttendanceDto attendance)
        {
            if (attendance == null)
            {
                return BadRequest("Invalid attendance data");
            }

            return _attendanceService.AddAttendance(attendance)
                ? (IActionResult)Ok("Attendance created successfully")
                : BadRequest("Attendance  creation failed");
        }

        // PUT: api/Attendance/5
        [HttpPut("{id}")]
        public IActionResult UpdateAttendance(long id, [FromBody] AttendanceDto attendance)
        {
            var existingAttendance = _attendanceService.Get(id);

            if (existingAttendance == null)
            {
                return NotFound();
            }

            _attendanceService.UpdateAttendance(attendance);

            return Ok(attendance);
        }

        // DELETE: api/Attendance/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAttendance(long id)
        {
            var existingAttendance = _attendanceService.Get(id);

            return existingAttendance == null 
                ? (IActionResult)NotFound() 
                : Ok(_attendanceService.DeleteAttendance(id));
        }
    }
}
