using Microsoft.EntityFrameworkCore;
using iBOS_Assignment.DAL.Seeders;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEmployee();
            modelBuilder.SeedAttendance();
        }
    }
}
