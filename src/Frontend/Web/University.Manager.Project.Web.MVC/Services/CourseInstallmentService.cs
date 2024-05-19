using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Services
{
    public class CourseInstallmentService(HttpClient client, string basePath = "api/v1/financial") : BaseService<CourseInstallmentViewModel>(client, basePath), ICourseInstallmentService
    {
    }
}
