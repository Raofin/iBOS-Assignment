using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace iBOS_Assignment.DAL.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "EmployeeId is required.")]
        public long EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "AttendanceDate is required.")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; } = DateTime.Now; // Default value is the current date.

        [DefaultValue(false)]
        public bool IsPresent { get; set; } = false; // Default value is false.

        [DefaultValue(false)]
        public bool IsAbsent { get; set; } = false;

        [DefaultValue(false)]
        public bool IsOffDay { get; set; } = false;
    }
}
