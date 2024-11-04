using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;

namespace University.Manager.Project.Course.Infra.Data.Repositories
{
    public class CourseCategoryRepository(ApplicationContext context) : BaseRepository<CourseCategory>(context), ICourseCategoryRepository
    {
    }
}
