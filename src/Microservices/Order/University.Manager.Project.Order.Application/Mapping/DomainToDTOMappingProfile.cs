using AutoMapper;
using University.Manager.Project.Order.Application.DTOs;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Domain.Entities;
using University.Manager.Project.Order.Domain.Entities.Enum;

namespace University.Manager.Project.Order.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<OrderEntity, OrderEntityDTO>().ReverseMap();
            CreateMap<OrderEntity, OrderEntityRequestDTO>().ReverseMap();
            CreateMap<OrderEntityRequestDTO, OrderEntity>().ReverseMap();
            CreateMap<OrderEntityRequestDTO, OrderEntityDTO>().ReverseMap();

        }
        public static OrderEntity MapOrderEntityRequestDTOToOrderEntity(OrderEntityRequestDTO model)
        {
            return new OrderEntity()
            {
                Attachment = model.Attachment,
                Message = model.Message,
                OrderType = (ETypeOrder)model.OrderType,
                Title = model.Title,
                UserId = model.UserId,
                Id = model.Id,
                CreationData = DateTime.Now,
                UpdatedData = DateTime.Now
            };

        }
        public static OrderEntity MapOrderEntityRequestDTOToOrderEntity(OrderEntityDTO model)
        {
            return new OrderEntity()
            {
                Attachment = model.Attachment,
                Message = model.Message,
                OrderType = (ETypeOrder)model.OrderType,
                Title = model.Title,
                UserId = model.UserId,
                Id = model.Id,
                CreationData = DateTime.Now,
                UpdatedData = DateTime.Now
            };

        }
    }
}
