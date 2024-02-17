using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;

namespace University.Manager.Project.Course.Infra.Data.Repositories
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly ApplicationContext _context;
        public CourseCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CourseCategory> CreateModelAsync(CourseCategory entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.CourseCategories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CourseCategory> DeleteModelAsync(CourseCategory entity)
        {
            _context.ChangeTracker.Clear();
            _context.CourseCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CourseCategory>> GetAllAsync()
        {
            return await _context.CourseCategories.ToListAsync();
        }

        public async Task<CourseCategory> GetByIdAsync(long id)
        {
            return await _context.CourseCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CourseCategory> UpdateModelAsync(CourseCategory entity)
        {
            entity.UpdateCourseCategory(entity.Name, entity.Description);
            entity.CreationData = _context.CourseCategories.FirstAsync(x => x.Id == entity.Id).Result.CreationData;
            _context.ChangeTracker.Clear();
            _context.CourseCategories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
