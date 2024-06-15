using University.Manager.Project.Student.Application.DTOs;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Student.Application.Interfaces
{
    public interface IStudentService : IBaseService<StudentEntityDTO, StudentEntityRequestDTO>
    {
        Task<StudentEntityDTO> GetStudentByCourseId(long id);
    }
}
