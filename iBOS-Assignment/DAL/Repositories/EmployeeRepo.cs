using System.Collections.Generic;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Repositories
{
    public class EmployeeRepo : IRepo<Employee, long, bool>
    {
        public List<Employee> Get()
        {
            throw new System.NotImplementedException();
        }

        public Employee Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Employee obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Employee obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
