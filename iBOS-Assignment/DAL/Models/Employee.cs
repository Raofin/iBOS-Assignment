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

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string EmployeeName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string EmployeeCode { get; set; }

        [Required]
        public int EmployeeSalary { get; set; }

        public long SupervisorId { get; set; }

        // Navigation property to access Employee's Attendances
        public ICollection<Attendance> Attendances { get; set; }
    }
}
