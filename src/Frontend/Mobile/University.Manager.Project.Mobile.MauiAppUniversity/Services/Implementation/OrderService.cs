using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class OrderService(HttpClient client, string basePath = "api/v1/order") : BaseService<OrderViewModel>(client, basePath), IOrderService
    {
    }
}
