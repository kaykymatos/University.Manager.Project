using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class OrderService(HttpClient client, IOrderRepository repo, string basePath = "api/v1/order") : BaseService<OrderViewModel, IOrderRepository>(client, basePath,repo), IOrderService
    {
    }
}
