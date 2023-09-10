using AutoMapper;
using iBOS_Assignment.API.Dtos;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.BLL.MappingProfiles
{
    public class AttendanceMappingProfile : Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<Attendance, AttendanceDto>();
        }
    }
}
