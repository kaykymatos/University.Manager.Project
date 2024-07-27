using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;

namespace University.Manager.Project.Course.Infra.Data.Repositories
{
    public class CourseRepository(ApplicationContext context) : BaseRepository<CourseEntity>(context), ICourseRepository
    {
        private readonly ApplicationContext _context = context;

        public async Task<IEnumerable<CourseEntity>> GetCourseByCategoryId(long categoryId)
        {
            List<CourseEntity> listModel = await _context.Courses.Where(x => x.CourseCategoryId == categoryId).ToListAsync();
            return listModel;
        }
        public override async Task<CourseEntity> GetByIdAsync(long id) => await _context.Courses.Include(x => x.CourseCategory).FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<IEnumerable<CourseEntity>> GetAllAsync() => await _context.Courses.Include(x => x.CourseCategory).ToListAsync();

    }
}
