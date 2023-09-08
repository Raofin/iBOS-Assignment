using iBOS_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace iBOS_Assignment.DAL.Seeders
{
    public static class EmployeeSeeder
    {
        public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    EmployeeId = 502030,
                    EmployeeCode = "EMP320",
                    EmployeeName = "Mehedi Hasan",
                    EmployeeSalary = 50000,
                    SupervisorId = 502036
                },
                new Employee {
                    EmployeeId = 502031,
                    EmployeeCode = "EMP321",
                    EmployeeName = "Ashikur Rahman",
                    EmployeeSalary = 45000,
                    SupervisorId = 502036
                },
                new Employee {
                    EmployeeId = 502032,
                    EmployeeCode = "EMP322",
                    EmployeeName = "Rakibul Islam",
                    EmployeeSalary = 52000,
                    SupervisorId = 502030
                },
                new Employee {
                    EmployeeId = 502033,
                    EmployeeCode = "EMP323",
                    EmployeeName = "Hasan Abdullah",
                    EmployeeSalary = 46000,
                    SupervisorId = 502031
                },
                new Employee {
                    EmployeeId = 502034,
                    EmployeeCode = "EMP324",
                    EmployeeName = "Akib Khan",
                    EmployeeSalary = 66000,
                    SupervisorId = 502032
                },
                new Employee {
                    EmployeeId = 502035,
                    EmployeeCode = "EMP325",
                    EmployeeName = "Rasel Shikder",
                    EmployeeSalary = 53500,
                    SupervisorId = 502033
                },
                new Employee {
                    EmployeeId = 502036,
                    EmployeeCode = "EMP326",
                    EmployeeName = "Selim Reja",
                    EmployeeSalary = 59000,
                    SupervisorId = 502035
                }
            );
        }
    }
}
