using University.Manager.Project.Web.Blazor.Models;
using University.Manager.Project.Web.Blazor.Services.Interfaces;

namespace University.Manager.Project.Web.Blazor.Services.Implementation
{
    public class CourseService(HttpClient client, string basePath = "api/v1/course") : BaseService<CourseViewModel>(client, basePath), ICourseService
    {
    }
}
