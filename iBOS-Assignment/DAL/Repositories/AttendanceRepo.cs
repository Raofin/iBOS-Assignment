using System;
using System.Collections.Generic;
using System.Linq;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace iBOS_Assignment.DAL.Repositories
{
    public class AttendanceRepo : IRepo<Attendance, long, bool>
    {
        private readonly ApplicationDbContext _context;

        // Constructor for the AttendanceRepo class, which injects an instance of ApplicationDbContext.
        public AttendanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a list of attendance records for a specific month and year.
        public List<Attendance> GetMonthlyAttendanceReport(int year, int month)
        {
            var reportData = _context.EmployeeAttendances
                .Include(a => a.Employee)
                .Where(a => a.AttendanceDate.Year == year && a.AttendanceDate.Month == month)
                .ToList();

            return reportData;
        }

        public List<Attendance> Get()
        {
            return _context.EmployeeAttendances.ToList();
        }

        public Attendance Get(long id)
        {
            return _context.EmployeeAttendances.Find(id);
        }

        public bool Add(Attendance obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _context.EmployeeAttendances.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var attendanceToDelete = _context.EmployeeAttendances.Find(id);
            if (attendanceToDelete == null)
                return false;

            _context.EmployeeAttendances.Remove(attendanceToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Attendance obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var existingAttendance = _context.EmployeeAttendances.Find(obj.Id);

            if (existingAttendance == null)
                return false;

            // Update the properties of the existing attendance record.
            existingAttendance.EmployeeId = obj.EmployeeId;
            existingAttendance.AttendanceDate = obj.AttendanceDate;
            existingAttendance.IsPresent = obj.IsPresent;
            existingAttendance.IsAbsent = obj.IsAbsent;
            existingAttendance.IsOffDay = obj.IsOffDay;

            _context.SaveChanges();
            return true;
        }
    }
}
