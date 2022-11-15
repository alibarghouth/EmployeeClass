using AutoMapper;
using EmployeeClass.Dto;
using EmployeeClass.Model;

namespace EmployeeClass.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(src => src.MyImg, option => option.Ignore())
                .ForMember(src => src.MyVideo, option => option.Ignore());

            CreateMap<Employee, AllDetails>();

            CreateMap<DeparmentDto, Department>();
            
        }
    }
}
