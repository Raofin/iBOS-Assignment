using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Repositories;

namespace iBOS_Assignment.DAL
{
    // This class is responsible for creating repository instances
    public class DataAccessFactory
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the application's database context
        public DataAccessFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create and return an instance of the Employee repository
        public IEmployeeRepository EmployeeRepository()
        {
            return new EmployeeRepo(_context);
        }

        // Create and return an instance of the Attendance repository
        public IAttendanceRepo AttendanceRepository()
        {
            return new AttendanceRepo(_context);
        }
    }
}
