using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class OrderRepository : BaseRepository<OrderViewModel>,IOrderRepository
    {
        public OrderRepository(LiteDatabase database) : base(database, "Orders")
        {
        }
    }
}
