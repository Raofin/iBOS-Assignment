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

        // Constructor for the AttendanceService class, which injects an instance of AttendanceRepo.
        public AttendanceService(AttendanceRepo attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        // AutoMapper configuration to map between AttendanceDto and Attendance entities.
        private static readonly IMapper _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<AttendanceDto, Attendance>();
            cfg.CreateMap<Attendance, AttendanceDto>();
        }));

        // Calculates the monthly attendance report for a given year and month.
        public List<MonthlyAttendanceReportDto> CalculateMonthlyReport(int year, int month)
        {
            // Retrieve attendance records for the specified year and month.
            var attendanceRecords = _attendanceRepo.GetMonthlyAttendanceReport(year, month);

            // Group attendance records by employee and calculate the monthly report data.
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

        private decimal CalculateSalary(IGrouping<Employee, Attendance> group)
        {
            decimal totalSalary = group.Key.EmployeeSalary;

            return totalSalary;
        }

        // Retrieves all attendance records and maps them to AttendanceDto objects.
        public List<AttendanceDto> Get()
        {
            var data = _attendanceRepo.Get();
            return _mapper.Map<List<AttendanceDto>>(data);
        }

        // Retrieves an attendance record by its ID and maps it to an AttendanceDto object.
        public AttendanceDto Get(long id)
        {
            var data = _attendanceRepo.Get(id);

            return _mapper.Map<AttendanceDto>(data);
        }

        // Adds a new attendance record based on the provided AttendanceDto.
        public bool AddAttendance(AttendanceDto attendance)
        {
            var employeeAttendance = _mapper.Map<Attendance>(attendance);
            return _attendanceRepo.Add(employeeAttendance);
        }

        // Updates an existing attendance record based on the provided AttendanceDto.
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

        // Deletes an attendance record by its ID.
        public bool DeleteAttendance(long id)
        {
            var existingAttendance = _attendanceRepo.Get(id);

            return existingAttendance != null
                ? _attendanceRepo.Delete(id)
                : throw new Exception("Attendance not found");
        }
    }
}
