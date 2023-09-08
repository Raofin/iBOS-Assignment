using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace iBOS_Assignment.DAL.Models
{
    public class EmployeeAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DefaultValue(typeof(DateTime), "GETDATE()")]
        public DateTime AttendanceDate { get; set; } = DateTime.Now;

        [DefaultValue(false)]
        public bool IsPresent { get; set; } = false;

        [DefaultValue(false)]
        public bool IsAbsent { get; set; } = false;

        [DefaultValue(false)]
        public bool IsOffDay { get; set; } = false;
    }
}
