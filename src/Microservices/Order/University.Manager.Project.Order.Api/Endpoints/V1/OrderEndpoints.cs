using FluentValidation;
using University.Manager.Project.Order.Application.DTOs;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Interfaces;

namespace University.Manager.Project.Order.Api.Endpoints.V1
{
    public class OrderEndpoints : BaseEndpoints<
        OrderEntityDTO,
        OrderEntityRequestDTO,
        IOrderService,
        IValidator<OrderEntityRequestDTO>>
    {
        protected override string BaseRoute => "api/v1/order";
    }

}
