using System;
using System.Collections.Generic;
using System.Linq;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Repositories
{
    public class AttendanceRepo : IRepo<EmployeeAttendance, long, bool>
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmployeeAttendance> Get()
        {
            return _context.EmployeeAttendances.ToList();
        }

        public EmployeeAttendance Get(long id)
        {
            return _context.EmployeeAttendances.Find(id);
        }

        public bool Add(EmployeeAttendance obj)
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

        public bool Update(EmployeeAttendance obj)
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
