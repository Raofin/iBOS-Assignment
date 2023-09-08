using System.Collections.Generic;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;

namespace iBOS_Assignment.BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepo _employeeRepo;

        public EmployeeService(EmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<Employee> Get()
        {
            return _employeeRepo.Get();
        }

        public Employee Get(long id)
        {
            return _employeeRepo.Get(id);
        }

        public Employee Update(Employee employee)
        {
            var existingEmployee = _employeeRepo.Get(employee.EmployeeId);
            if (existingEmployee == null)
            {
                return null;
            }

            _employeeRepo.Update(existingEmployee);

            return existingEmployee;
        }

        public Employee Delete(long id)
        {
            var existingEmployee = _employeeRepo.Get(id);
            if (existingEmployee == null)
            {
                return null;
            }

            _employeeRepo.Delete(id);

            return existingEmployee;
        }

        public bool Create(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.EmployeeName) || string.IsNullOrEmpty(employee.EmployeeCode))
            {
                return false;
            }

            var createdEmployee = _employeeRepo.Add(employee);

            return createdEmployee;
        }

        public bool Exists(long id)
        {
            return _employeeRepo.Get(id) != null;
        }
    }

}
