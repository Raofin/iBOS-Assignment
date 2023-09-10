using System;
using System.Collections.Generic;
using System.Linq;
using iBOS_Assignment.DAL.Interfaces;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Repositories
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Update employee information ensuring EmployeeCode is unique.
        public bool Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            // Check if the updated EmployeeCode is unique among other existing employees.
            if (_context.Employees.Any(e =>
                    e.EmployeeId != employee.EmployeeId && // Ignore the updating employee
                    e.EmployeeCode == employee.EmployeeCode)) // Check if the updated code is unique
            {
                throw new InvalidOperationException("EmployeeCode must be unique.");
            }

            var existingEmployee = _context.Employees.Find(employee.EmployeeId);

            if (existingEmployee == null)
                throw new InvalidOperationException("Employee not found for update.");

            // Update properties of existingEmployee with the updated ones
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EmployeeCode = employee.EmployeeCode;
            existingEmployee.EmployeeSalary = employee.EmployeeSalary;
            existingEmployee.SupervisorId = employee.SupervisorId;

            return _context.SaveChanges() > 0;
        }

        // Retrieves the employee with the third-highest salary.
        public Employee GetEmployeeWithThirdHighestSalary()
        {
            return _context.Employees
                .OrderByDescending(e => e.EmployeeSalary) // Order employees by salary in descending order to find the highest earners at the top.
                .Skip(2) // Skip the first two employees
                .Take(1) // Take one employee, which will be the 3rd highest salary
                .FirstOrDefault(); // Retrieve the first (or default) element from the filtered result.
        }

        // Retrieves a list of employees who have no absent records and orders them by salary.
        public List<Employee> GetEmployeesWithNoAbsentRecords()
        {
            return _context.Employees
                .Where(e =>
                    // Filter employees based on the absence records
                    // Check if there are no associated Attendance with IsAbsent set to true.
                    !_context.EmployeeAttendances.Any(a => a.EmployeeId == e.EmployeeId && a.IsAbsent))
                .OrderByDescending(e => e.EmployeeSalary) // Order the result by employee salary in descending order.
                .ToList(); // Convert the result to a list and return it.
        }

        // Get the employee hierarchy starting from the given employee ID.
        public List<Employee> GetHierarchyByEmployeeId(long employeeId)
        {
            var hierarchy = new List<Employee>();
            var visitedSupervisorIds = new HashSet<long>(); // Keep track of visited supervisor IDs
            var currentEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

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

        public bool Add(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Add(employee);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            var employeeToDelete = _context.Employees.Find(id);

            if (employeeToDelete == null)
                throw new InvalidOperationException("Employee not found for deletion.");

            _context.Employees.Remove(employeeToDelete);
            return _context.SaveChanges() > 0;
        }

        public bool EmployeeCodeExists(string employeeCode)
        {
            // Check if any employee with the given EmployeeCode exists
            return _context.Employees.Any(e => e.EmployeeCode == employeeCode);
        }
    }
}
