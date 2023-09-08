using System;
using iBOS_Assignment.BLL.Dtos;
using System.Collections.Generic;
using iBOS_Assignment.DAL.Models;
using iBOS_Assignment.DAL.Repositories;
using AutoMapper;

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
