using System;
using iBOS_Assignment.BLL.Dtos;
using System.Collections.Generic;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;
using AutoMapper;
using System.Linq;

namespace iBOS_Assignment.BLL.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepo _attendanceRepo;

        public AttendanceService(AttendanceRepo attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        private static readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<AttendanceDto, Attendance>();
            cfg.CreateMap<Attendance, AttendanceDto>();
        }));

        public List<MonthlyAttendanceReportDto> CalculateMonthlyReport(int year, int month)
        {
            // Implement logic to calculate the monthly attendance report
            // This may involve querying attendance records, aggregating data, and performing calculations

            // Example: Query attendance records for the specified month and year
            var attendanceRecords = _attendanceRepo.GetMonthlyAttendanceReport(year, month);

            // Example: Group and calculate attendance data by employee
            var reportData = attendanceRecords
                .GroupBy(a => a.Employee)
                .Select(group => new MonthlyAttendanceReportDto {
                    EmployeeName = group.Key.EmployeeName,
                    AttendanceDate = group.Key.Attendances.Select(a => a.AttendanceDate).FirstOrDefault(),
                    TotalCalculatedSalary = CalculateSalary(group),
                    TotalPresent = group.Count(a => a.IsPresent),
                    TotalAbsent = group.Count(a => a.IsAbsent),
                    TotalOffday = group.Count(a => a.IsOffDay)
                })
                .ToList();

            return reportData;
        }

        // Implement additional business logic methods if needed

        private decimal CalculateSalary(IGrouping<Employee, Attendance> group)
        {
            // Implement logic to calculate the total calculated salary for an employee
            // You can use information from attendance records and the employee's salary
            // This is a simplified example; you should adapt it to your actual calculation logic

            decimal totalSalary = group.Key.EmployeeSalary;

            // Adjust the totalSalary based on attendance data if needed

            return totalSalary;
        }

        public List<AttendanceDto> Get()
        {
            var data = _attendanceRepo.Get();
            return _mapper.Map<List<AttendanceDto>>(data);
        }

        public AttendanceDto Get(long id)
        {
            var data = _attendanceRepo.Get(id);

            return _mapper.Map<AttendanceDto>(data);
        }

        public bool AddAttendance(AttendanceDto attendance)
        {
            var employeeAttendance = _mapper.Map<Attendance>(attendance);
            return _attendanceRepo.Add(employeeAttendance);
        }

        public bool UpdateAttendance(AttendanceDto attendance)
        {
            var existingAttendance = _attendanceRepo.Get(attendance.Id);

            if (existingAttendance == null)
            {
                throw new Exception("Attendance not found");
            }

            var data = _mapper.Map<Attendance>(existingAttendance);

            _mapper.Map(attendance, data);

            return _attendanceRepo.Update(data);
        }

        public bool DeleteAttendance(long id)
        {
            var existingAttendance = _attendanceRepo.Get(id);

            return existingAttendance != null
                ? _attendanceRepo.Delete(id)
                : throw new Exception("Attendance not found");
        }
    }
}
