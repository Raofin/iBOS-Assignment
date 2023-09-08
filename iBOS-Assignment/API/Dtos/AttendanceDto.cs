using iBOS_Assignment.DAL.Models;
using System;

namespace iBOS_Assignment.API.Dtos
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
