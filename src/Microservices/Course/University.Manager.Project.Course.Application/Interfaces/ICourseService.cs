using University.Manager.Project.Course.Application.DTOs;

namespace University.Manager.Project.Course.Application.Interfaces
{
    public interface ICourseService : IBaseService<CourseEntityDTO>
    {
        Task<IEnumerable<CourseEntityDTO>> GetCourseByCategoryId(long categoryId);
    }
}
