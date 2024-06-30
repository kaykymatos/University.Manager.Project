
using University.Manager.Project.Web.Blazor.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class CourseService(HttpClient client, string basePath = "api/v1/course") : BaseService<CourseViewModel>(client, basePath), ICourseService
    {
    }
}
