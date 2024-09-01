using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseInstallmentService(HttpClient client, string basePath = "api/v1/financial") : BaseService<CourseInstallmentViewModel>(client, basePath), ICourseInstallmentService
    {
    }
}
