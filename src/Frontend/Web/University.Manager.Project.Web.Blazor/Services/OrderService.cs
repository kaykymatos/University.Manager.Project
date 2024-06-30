using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class OrderService(HttpClient client, string basePath = "api/v1/order") : BaseService<OrderViewModel>(client, basePath), IOrderService
    {
    }
}
