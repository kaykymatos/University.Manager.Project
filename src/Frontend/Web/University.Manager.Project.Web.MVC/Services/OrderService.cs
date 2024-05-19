using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Services
{
    public class OrderService(HttpClient client, string basePath = "api/v1/order") : BaseService<OrderViewModel>(client, basePath), IOrderService
    {
    }
}
