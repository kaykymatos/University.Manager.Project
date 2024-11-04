using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseCategoryService(HttpClient client, ICourseCategoryRepository repo, string basePath = "api/v1/courseCategory") : BaseService<CourseCategoryViewModel, ICourseCategoryRepository>(client, basePath,repo), ICourseCategoryService
    {
    }
}
