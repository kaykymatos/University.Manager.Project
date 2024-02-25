using University.Manager.Project.Student.Domain.Entities;

namespace University.Manager.Project.Student.Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository<StudentEntity>
    {
        Task<StudentEntity> GetStudentByCourseId(long id);
    }
}
