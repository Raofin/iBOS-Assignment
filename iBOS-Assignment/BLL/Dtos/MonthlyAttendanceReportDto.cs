using System;

namespace iBOS_Assignment.BLL.Dtos
{
    public class MonthlyAttendanceReportDto
    {
        public string EmployeeName { get; set; }

        public DateTime AttendanceDate { get; set; }

        public decimal TotalCalculatedSalary { get; set; }

        public int TotalPresent { get; set; }

        public int TotalAbsent { get; set; }

        public int TotalOffDay { get; set; }
    }
}
