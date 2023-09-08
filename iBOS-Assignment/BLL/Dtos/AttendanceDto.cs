using iBOS_Assignment.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace iBOS_Assignment.BLL.Dtos
{
    public class AttendanceDto
    {
        public long Id { get; set; }

        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; }

        public bool IsAbsent { get; set; }

        public bool IsOffDay { get; set; }
    }
}
