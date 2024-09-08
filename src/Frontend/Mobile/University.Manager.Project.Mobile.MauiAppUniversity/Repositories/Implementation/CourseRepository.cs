using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class CourseRepository : BaseRepository<CourseViewModel>, ICourseRepository
    {
        public CourseRepository(LiteDatabase database) : base(database, "Courses")
        {
        }
    }
}
