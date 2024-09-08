using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class CourseInstallmentRepository : BaseRepository<CourseInstallmentViewModel>,ICourseInstallmentRepository
    {
        public CourseInstallmentRepository(LiteDatabase database) : base(database, "CourseInstallments")
        {
        }
    }
}
