using University.Manager.Project.Web.Blazor.Models;
using University.Manager.Project.Web.Blazor.Services.Interfaces;

namespace University.Manager.Project.Web.Blazor.Services.Implementation
{
    public class CourseCategoryService(HttpClient client, string basePath = "api/v1/courseCategory") : BaseService<CourseCategoryViewModel>(client, basePath), ICourseCategoryService
    {
    }
}
