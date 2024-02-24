using FluentValidation;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Order.Application.Validation
{
    public class OrderEntityRequestDTOValidation : AbstractValidator<OrderEntityRequestDTO>
    {
        public OrderEntityRequestDTOValidation()
        {

        }
    }
}
