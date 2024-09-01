using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class OrderRepository : BaseRepository<OrderViewModel>
    {
        public OrderRepository(LiteDatabase database) : base(database, "Orders")
        {
        }
    }
}
