using AutoMapper;
using University.Manager.Project.Student.Application.DTOs;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Domain.Entities;

namespace University.Manager.Project.Student.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {

            CreateMap<StudentEntity, StudentEntityDTO>().ReverseMap();

            CreateMap<StudentEntityRequestMessageDTO, StudentEntityRequestDTO>().ReverseMap();
            CreateMap<StudentEntityDTO, StudentEntityRequestDTO>().ReverseMap();
            CreateMap<StudentEntity, StudentEntityRequestDTO>().ReverseMap();
        }
    }
}
