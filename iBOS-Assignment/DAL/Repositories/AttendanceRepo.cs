using System.Collections.Generic;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Repositories
{
    public class AttendanceRepo : IRepo<EmployeeAttendance, long, bool>
    {
        public bool Add(EmployeeAttendance obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<EmployeeAttendance> Get()
        {
            throw new System.NotImplementedException();
        }

        public EmployeeAttendance Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(EmployeeAttendance obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
