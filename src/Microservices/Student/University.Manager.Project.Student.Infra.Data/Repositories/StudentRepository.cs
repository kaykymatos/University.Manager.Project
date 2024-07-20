using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Student.Domain.Entities;
using University.Manager.Project.Student.Domain.Interfaces;
using University.Manager.Project.Student.Infra.Data.Context;

namespace University.Manager.Project.Student.Infra.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMultipleAsync(IEnumerable<long> ids)
        {
            try
            {
                var itemsToDelete = await _context.Students.Where(item => ids.Contains(item.Id)).ToListAsync();
                _context.Students.RemoveRange(itemsToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<StudentEntity> CreateModelAsync(StudentEntity entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<StudentEntity> DeleteModelAsync(StudentEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentEntity> GetByIdAsync(long id) => await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<StudentEntity> GetStudentByCourseId(long id) => await _context.Students.FirstOrDefaultAsync(x => x.CourseId == id);

        public async Task<StudentEntity> UpdateModelAsync(StudentEntity entity)
        {
            entity.UpdateDomain(entity.RegisterCode, entity.CourseId, entity.Name, entity.Email);
            entity.CreationData = _context.Students.FirstAsync(x => x.Id == entity.Id).Result.CreationData;

            _context.ChangeTracker.Clear();
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
