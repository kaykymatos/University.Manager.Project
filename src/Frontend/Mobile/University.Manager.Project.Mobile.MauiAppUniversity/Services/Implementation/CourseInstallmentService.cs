using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseInstallmentService(HttpClient client, ICourseInstallmentRepository repo, string basePath = "api/v1/financial") : BaseService<CourseInstallmentViewModel, ICourseInstallmentRepository>(client, basePath,repo), ICourseInstallmentService
    {
    }
}
