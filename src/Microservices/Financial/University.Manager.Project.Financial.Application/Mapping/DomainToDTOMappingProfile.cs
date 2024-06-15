using AutoMapper;
using University.Manager.Project.Financial.Application.DTOs;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Domain.Entities;

namespace University.Manager.Project.Financial.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CourseInstallments, CourseInstallmentsDTO>().ReverseMap();
            CreateMap<CourseInstallmentsDTO, CourseInstallmentsRequestDTO>().ReverseMap();
            CreateMap<CourseInstallments, CourseInstallmentsRequestDTO>().ReverseMap();

        }
    }
}
