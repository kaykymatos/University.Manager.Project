using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseService(HttpClient client, string basePath = "api/v1/course") : BaseService<CourseViewModel>(client, basePath), ICourseService
    {
    }
}
