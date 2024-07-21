using University.Manager.Project.Web.Blazor.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class OrderService(HttpClient client, string basePath = "api/v1/order") : BaseService<OrderViewModel>(client, basePath), IOrderService
    {
    }
}
