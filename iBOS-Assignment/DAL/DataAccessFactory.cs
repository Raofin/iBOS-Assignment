using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;

namespace iBOS_Assignment.DAL
{
    public class DataAccessFactory
    {
        private static ApplicationDbContext _context;

        private DataAccessFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public static IRepo<Employee, long, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo(_context);
        }

        public static IRepo<EmployeeAttendance, long, bool> AttendanceDataAccess()
        {
            return new AttendanceRepo(_context);
        }
    }
}
