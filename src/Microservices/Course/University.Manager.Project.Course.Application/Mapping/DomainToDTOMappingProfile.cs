using AutoMapper;
using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Domain.Entities;

namespace University.Manager.Project.Course.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CourseEntity, CourseEntityDTO>().ReverseMap();
            CreateMap<CourseCategory, CourseCategoryDTO>().ReverseMap();
        }
    }
}
