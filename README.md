# iBOS-Assignment

An ASP.NET Core API project developed with C#, .NET Core, MSSQL, and Entity Framework Core using the SOLID architectural pattern and other interesting concepts.

### Live: [https://ibos-assignment.raofin.net](https://ibos-assignment.raofin.net)

## Screenshot
<img src="/Screenshot.png">

## Implemented Concepts
✔️ [**JWT Token:**](https://github.com/Raofin/iBOS-Assignment/blob/6f45749eca339f515831bd1e04b27ae3aff94b5f/iBOS-Assignment/API/Startup.cs#L99-L112) JWT token authentication for secure access to the APIs.

✔️ [**SQLite:**](https://github.com/Raofin/iBOS-Assignment/blob/6f45749eca339f515831bd1e04b27ae3aff94b5f/iBOS-Assignment/API/Startup.cs#L34-L35) SQLite as the database storage.

✔️ [**Repository Pattern:**](https://github.com/Raofin/iBOS-Assignment/tree/master/iBOS-Assignment/DAL/Repositories) Repository pattern, providing a structured approach to data access and manipulation.

✔️ **SOLID Principles:** The SOLID architecture principles to enhance code maintainability, extensibility, and reusability.

✔️ [**Model Validation**](https://github.com/Raofin/iBOS-Assignment/tree/master/iBOS-Assignment/DAL/Models) Perfect model validations to ensure the integrity and validity of data inputs.

## [**API Endpoints**](https://github.com/Raofin/iBOS-Assignment/blob/master/iBOS-Assignment/API/Controllers/ApiTasksController.cs)

- **API#01. Update Employee Name and Employee Code**
   - Allows to update an employee's name and code.
   - Ensures uniqueness of employee codes to prevent duplicates.
   - `PUT /api/tasks/UpdateNameAndCode/{employeeId}`

- **API#02. Get 3rd Highest Salary Employee**
   - Retrieves the employee who has the 3rd highest salary.
   - `GET /api/tasks/GetThirdHighestSalaryEmployee`

- **API#03. Get Employees with No Absent Records**
   - Lists all employees sorted by maximum to minimum salary, who have no absent records.
   - `GET /api/tasks/GetEmployeesWithNoAbsentRecords`

- **API#04. Get Monthly Attendance Report**
   - Generates a detailed monthly attendance report for all employees.
   - Report columns include Employee Name, Date, Salary, Total Present, Total Absent, and Total Offday.
   - `GET /api/tasks/MonthlyReport`

- **API#05. Get Employee Hierarchy**
   - Retrieves the employee hierarchy based on supervisor relationships.
   - Input an Employee ID, and the API returns a hierarchical list of employees leading to the specified employee.
   - `GET /api/tasks/GetHierarchy/{employeeId}`

- **API#06. Get Auth Token**
   - Generates and returns a JWT authentication token.
   - `GET /api/Auth/GetToken`

## License
This project is licensed under the [BSD 3-Clause](LICENSE).