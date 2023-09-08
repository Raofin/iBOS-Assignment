using iBOS_Assignment.BLL.Dtos;
using System.Collections.Generic;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;

namespace iBOS_Assignment.BLL.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepo _attendanceRepo;

        public AttendanceService(AttendanceRepo attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        public List<EmployeeAttendance> GetAllAttendances()
        {
            return _attendanceRepo.Get();
        }

        public EmployeeAttendance GetAttendanceById(long id)
        {
            return _attendanceRepo.Get(id);
        }

        public void AddAttendance(EmployeeAttendance employeeAttendance)
        {
            _attendanceRepo.Add(employeeAttendance);
        }

        public void UpdateAttendance(EmployeeAttendance employeeAttendance)
        {
            _attendanceRepo.Update(employeeAttendance);
        }

        public bool DeleteAttendance(long id)
        {
            return _attendanceRepo.Delete(id);
        }
    }
}
