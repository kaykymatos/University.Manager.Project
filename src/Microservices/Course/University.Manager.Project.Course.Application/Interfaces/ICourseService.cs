using University.Manager.Project.Course.Application.DTOs;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Course.Application.Interfaces
{
    public interface ICourseService : IBaseService<CourseEntityDTO, CourseEntityRequestDTO>
    {
        Task<IEnumerable<CourseEntityDTO>> GetCourseByCategoryId(long categoryId);
    }
}
