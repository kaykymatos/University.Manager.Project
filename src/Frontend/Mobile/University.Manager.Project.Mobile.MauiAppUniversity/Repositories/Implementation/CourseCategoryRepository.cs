using LiteDB;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;
using University.Manager.Project.Web.Blazor.Repositories.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation
{
    public class CourseCategoryRepository : BaseRepository<CourseCategoryViewModel>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(LiteDatabase database) : base(database, "CourseCategories")
        {
        }
    }
}
