
using University.Manager.Project.Web.Blazor.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class CourseCategoryService(HttpClient client, string basePath = "api/v1/courseCategory") : BaseService<CourseCategoryViewModel>(client, basePath), ICourseCategoryService
    {
    }
}
