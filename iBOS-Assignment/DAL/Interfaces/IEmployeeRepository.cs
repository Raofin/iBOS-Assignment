using iBOS_Assignment.DAL.Models;
using System.Collections.Generic;

namespace iBOS_Assignment.DAL.Interfaces
{
    public interface IEmployeeRepository : IRepo<Employee, long, bool>
    {
        Employee GetEmployeeWithThirdHighestSalary();
        List<Employee> GetEmployeesWithNoAbsentRecords();
        List<Employee> GetHierarchyByEmployeeId(long employeeId);
        bool EmployeeCodeExists(string employeeCode);
    }
}
