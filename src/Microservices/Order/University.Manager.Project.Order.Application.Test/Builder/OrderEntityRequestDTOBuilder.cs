using FizzWare.NBuilder;
using University.Manager.Project.Order.Application.DTOs.Enum;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Order.Application.Test.Builder
{
    public class OrderEntityRequestDTOBuilder : BuilderBase<OrderEntityRequestDTO>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<OrderEntityRequestDTO>.CreateNew()
                .With(x => x.UserId=1)
                .With(x => x.Title="Teste")
                .With(x => x.Message="Teste mensagem")
                .With(x => x.Attachment="")
                .With(x => x.OrderType= ETypeOrder.FINANCIAL_PROBLEM);
        }
    }
}
