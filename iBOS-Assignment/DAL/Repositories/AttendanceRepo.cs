using System;
using System.Collections.Generic;
using System.Linq;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace iBOS_Assignment.DAL.Repositories
{
    public class AttendanceRepo : IAttendanceRepo
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a list of attendance records for a specific month and year.
        public List<Attendance> GetMonthlyAttendanceReport(int year, int month)
        {
            return _context.EmployeeAttendances
                .Include(a => a.Employee)
                .Where(a => a.AttendanceDate.Year == year && a.AttendanceDate.Month == month)
                .ToList();
        }

        public List<Attendance> Get()
        {
            return _context.EmployeeAttendances.ToList();
        }

        public Attendance Get(long id)
        {
            return _context.EmployeeAttendances.Find(id);
        }

        public bool Add(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance));

            _context.EmployeeAttendances.Add(attendance);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            var attendanceToDelete = _context.EmployeeAttendances.Find(id);
            if (attendanceToDelete == null)
                return false;

            _context.EmployeeAttendances.Remove(attendanceToDelete);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance));

            var existingAttendance = _context.EmployeeAttendances.Find(attendance.Id);

            if (existingAttendance == null)
                return false;

            // Update the properties of the existing attendance record
            existingAttendance.EmployeeId = attendance.EmployeeId;
            existingAttendance.AttendanceDate = attendance.AttendanceDate;
            existingAttendance.IsPresent = attendance.IsPresent;
            existingAttendance.IsAbsent = attendance.IsAbsent;
            existingAttendance.IsOffDay = attendance.IsOffDay;

            return _context.SaveChanges() > 0;
        }
    }
}
