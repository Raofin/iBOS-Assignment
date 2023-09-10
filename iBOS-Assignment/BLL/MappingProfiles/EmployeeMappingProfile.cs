using AutoMapper;
using iBOS_Assignment.API.Dtos;
using iBOS_Assignment.DAL.Models;

namespace iBOS_Assignment.BLL.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
