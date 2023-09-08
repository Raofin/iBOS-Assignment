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

        public AttendanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Attendance> GetMonthlyAttendanceReport(int year, int month)
        {
            // Implement logic to query attendance records for the specified year and month
            // You'll need to filter and aggregate attendance records to generate the report
            // This implementation will depend on your data model and business requirements

            // Example: Query attendance data for the specified month and year
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
