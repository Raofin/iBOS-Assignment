# iBOS-Assignment

### **Description**:

This repository contains an Employee Management API built using C#, .NET Core, MSSQL, and Entity Framework Core. The API provides a set of endpoints to manage and retrieve employee data, along with advanced features like employee hierarchy, salary analysis, attendance reports, and more.

### **API Endpoints**:

1. **Update Employee Name and Employee Code** (`PUT /api/Employees/UpdateNameAndCode/{id}`):
   - Allows you to update an employee's name and code.
   - Ensures uniqueness of employee codes to prevent duplicates.

2. **Get 3rd Highest Salary Employee** (`GET /api/Employees/GetThirdHighestSalaryEmployee`):
   - Retrieves the employee who has the 3rd highest salary.

3. **Get Employees with No Absent Records** (`GET /api/Employees/GetEmployeesWithNoAbsentRecords`):
   - Lists all employees sorted by maximum to minimum salary, who have no absent records.

4. **Get Monthly Attendance Report** (`GET /api/Attendance/MonthlyReport`):
   - Generates a detailed monthly attendance report for all employees.
   - Report columns include Employee Name, Date, Salary, Total Present, Total Absent, and Total Offday.

5. **Get Employee Hierarchy** (`GET /api/Employees/GetHierarchy/{employeeId}`):
   - Retrieves the employee hierarchy based on supervisor relationships.
   - Input an Employee ID, and the API returns a hierarchical list of employees leading to the specified employee.
