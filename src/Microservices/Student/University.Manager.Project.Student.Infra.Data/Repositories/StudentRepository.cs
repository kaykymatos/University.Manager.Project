using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Student.Domain.Entities;
using University.Manager.Project.Student.Domain.Interfaces;
using University.Manager.Project.Student.Infra.Data.Context;

namespace University.Manager.Project.Student.Infra.Data.Repositories
{
    public class StudentRepository(ApplicationContext context) : BaseRepository<StudentEntity>(context), IStudentRepository
    {
        private readonly ApplicationContext _context = context;
        public virtual async Task<StudentEntity> GetStudentByCourseId(long id) => await _context.Students.FirstOrDefaultAsync(x => x.CourseId == id);

    }
}
