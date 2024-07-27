using University.Manager.Project.Web.Blazor.Models;
using University.Manager.Project.Web.Blazor.Services.Interfaces;

namespace University.Manager.Project.Web.Blazor.Services.Implementation
{
    public class OrderService(HttpClient client, string basePath = "api/v1/order") : BaseService<OrderViewModel>(client, basePath), IOrderService
    {
    }
}
