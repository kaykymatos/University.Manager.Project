using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class CourseInstallmentRepository : BaseRepository<CourseInstallmentViewModel>
    {
        public CourseInstallmentRepository(LiteDatabase database) : base(database, "CourseInstallments")
        {
        }
    }
}
