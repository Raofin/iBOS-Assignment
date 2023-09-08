using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetAllAttendances()
        {
            var attendances = _attendanceService.GetAllAttendances();
            return Ok(attendances);
        }

        // GET: api/Attendance/5
        [HttpGet("{id}")]
        public IActionResult GetAttendanceById(long id)
        {
            var attendance = _attendanceService.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        // POST: api/Attendance
        [HttpPost]
        public IActionResult AddAttendance([FromBody] EmployeeAttendance employeeAttendance)
        {
            if (employeeAttendance == null)
            {
                return BadRequest("Invalid attendance data");
            }

            _attendanceService.AddAttendance(employeeAttendance);

            return CreatedAtAction(nameof(GetAttendanceById), new { id = employeeAttendance.Id }, employeeAttendance);
        }

        // PUT: api/Attendance/5
        [HttpPut("{id}")]
        public IActionResult UpdateAttendance(long id, [FromBody] EmployeeAttendance employeeAttendance)
        {
            if (employeeAttendance == null || id != employeeAttendance.Id)
            {
                return BadRequest("Invalid attendance data");
            }

            var existingAttendance = _attendanceService.GetAttendanceById(id);
            if (existingAttendance == null)
            {
                return NotFound();
            }

            _attendanceService.UpdateAttendance(employeeAttendance);

            return Ok(employeeAttendance);
        }

        // DELETE: api/Attendance/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAttendance(long id)
        {
            var existingAttendance = _attendanceService.GetAttendanceById(id);
            if (existingAttendance == null)
            {
                return NotFound();
            }

            var deleted = _attendanceService.DeleteAttendance(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Attendance deletion failed");
            }
        }
    }
}
