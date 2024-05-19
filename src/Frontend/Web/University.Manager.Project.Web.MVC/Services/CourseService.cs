using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Services
{
    public class CourseService(HttpClient client, string basePath = "api/v1/course") : BaseService<CourseViewModel>(client, basePath), ICourseService
    {
    }
}
