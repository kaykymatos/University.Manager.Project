using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Manager.Project.Order.Domain.Entities;

namespace University.Manager.Project.Order.Domain.Interfaces
{
    public interface IOrderRepository : IBaseEntityRepository<OrderEntity>
    {
    }
}
