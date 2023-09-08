using System;
using System.Collections.Generic;
using System.Linq;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Repositories
{
    public class EmployeeRepo : IRepo<Employee, long, bool>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee GetEmployeeWithThirdHighestSalary()
        {
            return _context.Employees
                .OrderByDescending(e => e.EmployeeSalary)
                .Skip(2) // Skip the first two employees (0-based index)
                .Take(1) // Take one employee, which will be the 3rd highest salary
                .FirstOrDefault();
        }

        public List<Employee> GetEmployeesWithNoAbsentRecords()
        {
            return _context.Employees
                .Where(e => !_context.EmployeeAttendances.Any(a => a.EmployeeId == e.EmployeeId && a.IsAbsent))
                .OrderByDescending(e => e.EmployeeSalary)
                .ToList();
        }

        public List<Employee> GetHierarchyByEmployeeId(long employeeId)
        {
            List<Employee> hierarchy = new List<Employee>();
            HashSet<long> visitedSupervisorIds = new HashSet<long>(); // Keep track of visited supervisor IDs
            Employee currentEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            while (currentEmployee != null && !visitedSupervisorIds.Contains(currentEmployee.SupervisorId))
            {
                hierarchy.Add(currentEmployee);
                visitedSupervisorIds.Add(currentEmployee.SupervisorId); // Mark supervisor ID as visited
                currentEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == currentEmployee.SupervisorId);
            }

            hierarchy.Reverse(); // Reverse the hierarchy to start from the root supervisor

            return hierarchy;
        }

        public List<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public Employee Get(long id)
        {
            return _context.Employees.Find(id);
        }

        public bool Add(Employee obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _context.Employees.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var employeeToDelete = _context.Employees.Find(id);
            if (employeeToDelete == null)
                return false;

            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Employee obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var existingEmployee = _context.Employees.Find(obj.EmployeeId);
            if (existingEmployee == null)
                return false;

            // Update properties of existingEmployee with obj's properties
            existingEmployee.EmployeeName = obj.EmployeeName;
            existingEmployee.EmployeeCode = obj.EmployeeCode;
            existingEmployee.EmployeeSalary = obj.EmployeeSalary;
            existingEmployee.SupervisorId = obj.SupervisorId;

            _context.SaveChanges();
            return true;
        }

        public bool EmployeeCodeExists(string employeeCode)
        {
            // Check if any employee with the given EmployeeCode exists
            return _context.Employees.Any(e => e.EmployeeCode == employeeCode);
        }
    }
}
