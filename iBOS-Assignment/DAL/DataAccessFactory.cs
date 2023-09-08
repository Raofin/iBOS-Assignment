using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;

namespace iBOS_Assignment.DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, long, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }

        public static IRepo<EmployeeAttendance, long, bool> AttendanceDataAccess()
        {
            return new AttendanceRepo();
        }
    }
}
