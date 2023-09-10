using AutoMapper;
using iBOS_Assignment.BLL.Dtos;
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
