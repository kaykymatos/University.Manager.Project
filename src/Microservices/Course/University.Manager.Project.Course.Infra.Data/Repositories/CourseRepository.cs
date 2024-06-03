using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;

namespace University.Manager.Project.Course.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _context;
        public CourseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CourseEntity> CreateModelAsync(CourseEntity entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.Courses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<CourseEntity> DeleteModelAsync(CourseEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Courses.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CourseEntity>> GetAllAsync()
        {
            return await _context.Courses.Include(x => x.CourseCategory).ToListAsync();
        }

        public async Task<CourseEntity> GetByIdAsync(long id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CourseEntity>> GetCourseByCategoryId(long categoryId)
        {
            List<CourseEntity> listModel = await _context.Courses.Where(x => x.CourseCategoryId == categoryId).ToListAsync();
            return listModel;
        }

        public async Task<CourseEntity> UpdateModelAsync(CourseEntity entity)
        {
            entity.UpdateDomain(entity.Name, entity.Description, entity.Workload, entity.TotalValue);
            entity.CreationData = _context.Courses.FirstAsync(x => x.Id == entity.Id).Result.CreationData;

            _context.ChangeTracker.Clear();
            _context.Courses.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
