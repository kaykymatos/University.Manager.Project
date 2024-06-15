using AutoMapper;
using University.Manager.Project.Order.Application.DTOs;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Domain.Entities;

namespace University.Manager.Project.Order.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<OrderEntity, OrderEntityDTO>().ReverseMap();
            CreateMap<OrderEntity, OrderEntityRequestDTO>().ReverseMap();
            CreateMap<OrderEntityRequestDTO, OrderEntityDTO>().ReverseMap();

        }
    }
}
