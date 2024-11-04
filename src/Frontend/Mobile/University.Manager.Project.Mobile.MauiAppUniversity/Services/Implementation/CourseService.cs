using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseService(HttpClient client, ICourseRepository repo, string basePath = "api/v1/course") : BaseService<CourseViewModel, ICourseRepository>(client, basePath,repo), ICourseService
    {
    }
}
