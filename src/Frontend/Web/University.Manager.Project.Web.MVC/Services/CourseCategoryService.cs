using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Services
{
    public class CourseCategoryService(HttpClient client, string basePath = "api/v1/courseCategory") : BaseService<CourseCategoryViewModel>(client, basePath), ICourseCategoryService
    {
    }
}
