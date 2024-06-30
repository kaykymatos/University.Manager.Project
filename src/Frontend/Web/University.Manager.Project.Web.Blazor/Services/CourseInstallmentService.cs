
using University.Manager.Project.Web.Blazor.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class CourseInstallmentService(HttpClient client, string basePath = "api/v1/financial") : BaseService<CourseInstallmentViewModel>(client, basePath), ICourseInstallmentService
    {
    }
}
