using University.Manager.Project.Course.Domain.Entities;

namespace University.Manager.Project.Course.Domain.Interfaces
{
    public interface ICourseRepository : IBaseEntityRepository<CourseEntity>
    {
        Task<IEnumerable<CourseEntity>> GetCourseByCategoryId(long categoryId);
    }
}
