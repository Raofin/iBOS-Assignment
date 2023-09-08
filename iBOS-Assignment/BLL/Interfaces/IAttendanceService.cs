using System.Collections.Generic;
using iBOS_Assignment.API.Dtos;

namespace iBOS_Assignment.BLL.Interfaces
{
    public interface IAttendanceService
    {
        List<MonthlyAttendanceReportDto> CalculateMonthlyReport(int year, int month);

        List<AttendanceDto> Get();

        AttendanceDto Get(long id);

        bool AddAttendance(AttendanceDto attendance);

        bool UpdateAttendance(AttendanceDto attendance);

        bool DeleteAttendance(long id);
    }
}