using iBOS_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace iBOS_Assignment.DAL.Seeders
{
    public static class AttendanceSeeder
    {
        public static void SeedAttendance(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttendance>().HasData(
                new EmployeeAttendance {
                    Id = 1,
                    EmployeeId = 502030,
                    AttendanceDate = new DateTime(2023, 06, 24),
                    IsPresent = true,
                    IsAbsent = false,
                    IsOffDay = false
                },
                new EmployeeAttendance {
                    Id = 2,
                    EmployeeId = 502030,
                    AttendanceDate = new DateTime(2023, 06, 25),
                    IsPresent = false,
                    IsAbsent = true,
                    IsOffDay = false
                },
                new EmployeeAttendance {
                    Id = 3,
                    EmployeeId = 502031,
                    AttendanceDate = new DateTime(2023, 06, 25),
                    IsPresent = true,
                    IsAbsent = false,
                    IsOffDay = false
                }
            );
        }
    }
}
