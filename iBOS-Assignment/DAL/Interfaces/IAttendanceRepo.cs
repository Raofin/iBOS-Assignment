using System.Collections.Generic;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.DAL.Interfaces
{
    public interface IAttendanceRepo : IRepo<Attendance, long, bool>
    {
        List<Attendance> GetMonthlyAttendanceReport(int year, int month);
    }
}