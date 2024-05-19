using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Services
{
    public class StudentService(HttpClient client, string basePath = "api/v1/student") : BaseService<StudentViewModel>(client, basePath), IStudentService
    {
    }
}
