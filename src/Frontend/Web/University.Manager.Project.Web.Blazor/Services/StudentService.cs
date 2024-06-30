using University.Manager.Project.Web.Blazor.Models;

namespace University.Manager.Project.Web.Blazor.Services
{
    public class StudentService(HttpClient client, ICourseService courseService, string basePath = "api/v1/student") : BaseService<StudentViewModel>(client, basePath), IStudentService
    {
        private readonly ICourseService _courseService = courseService;
        public override async Task<IEnumerable<ApiErrorViewModel>> Create(StudentViewModel model, string token)
        {
            CourseViewModel getCursePrice = await _courseService.FindById(model.CourseId, token);
            model.TotalValue = getCursePrice.TotalValue;
            model.Workload = getCursePrice.Workload;
            return await base.Create(model, token);
        }
    }
}
