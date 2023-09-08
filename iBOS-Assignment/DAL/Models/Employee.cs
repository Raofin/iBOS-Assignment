using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iBOS_Assignment.DAL.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "EmployeeName is required.")]
        [StringLength(50, ErrorMessage = "EmployeeName must not exceed 50 characters.")]
        [Column(TypeName = "nvarchar(50)")]
        public string EmployeeName { get; set; }

        private string _employeeCode; // Private field to hold the original EmployeeCode.

        [Required(ErrorMessage = "EmployeeCode is required.")]
        [StringLength(10, ErrorMessage = "EmployeeCode must not exceed 10 characters.")]
        [Column(TypeName = "nvarchar(10)")]
        public string EmployeeCode {
            get => _employeeCode;
            set => _employeeCode = value?.ToUpperInvariant(); // Convert to uppercase.
        }

        [Required(ErrorMessage = "EmployeeSalary is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "EmployeeSalary must be a non-negative value.")]
        public int EmployeeSalary { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "SupervisorId must be a positive value.")]
        public long SupervisorId { get; set; } // Made nullable to allow employees without supervisors.

        // Navigation property to access Employee's Attendances
        public ICollection<Attendance> Attendances { get; set; }
    }
}
