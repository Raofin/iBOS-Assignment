using System.Collections.Generic;
using iBOS_Assignment.API.Dtos;

namespace iBOS_Assignment.BLL.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetThirdHighestSalaryEmployee();

        List<EmployeeDto> GetEmployeesWithNoAbsentRecords();

        List<EmployeeDto> GetHierarchyByEmployeeId(long employeeId);

        List<EmployeeDto> Get();

        EmployeeDto Get(long id);

        bool Update(EmployeeDto employee);

        bool Delete(long id);

        bool Create(EmployeeDto employeeDto);

        bool Exists(long id);
    }
}