using University.Manager.Project.Order.Domain.Entities;
using University.Manager.Project.Order.Domain.Interfaces;
using University.Manager.Project.Order.Infra.Data.Context;

namespace University.Manager.Project.Order.Infra.Data.Repositories
{
    public class OrderRepository(ApplicationContext context) : BaseRepository<OrderEntity>(context), IOrderRepository
    {

    }
}
