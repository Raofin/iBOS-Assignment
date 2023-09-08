using Microsoft.EntityFrameworkCore;
using iBOS_Assignment.DAL.Seeders;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor for the ApplicationDbContext class, which injects DbContextOptions.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Attendance> EmployeeAttendances { get; set; }

        // Method for configuring the database model and seeding initial data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data for the 'Employees' and 'EmployeeAttendances' tables.
            modelBuilder.SeedEmployee();
            modelBuilder.SeedAttendance();

            // Create a unique index on the 'EmployeeCode' property of the 'Employee' entity.
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();
        }
    }
}