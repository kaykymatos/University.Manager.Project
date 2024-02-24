using University.Manager.Project.Order.Application.DTOs;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Order.Application.Interfaces
{
    public interface IOrderService : IBaseService<OrderEntityDTO, OrderEntityRequestDTO>
    {
    }
}
