using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class CourseRepository : BaseRepository<CourseViewModel>
    {
        public CourseRepository(LiteDatabase database) : base(database, "Courses")
        {
        }
    }
}
