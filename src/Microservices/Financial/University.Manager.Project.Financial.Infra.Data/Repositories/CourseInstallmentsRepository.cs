using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Financial.Domain.Entities;
using University.Manager.Project.Financial.Domain.Interfaces;
using University.Manager.Project.Financial.Infra.Data.Context;

namespace University.Manager.Project.Financial.Infra.Data.Repositories
{
    public class CourseInstallmentsRepository : ICourseInstallmentsRepository
    {

        private readonly ApplicationContext _context;
        public CourseInstallmentsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseInstallments>> CreateMany(List<CourseInstallments> listModels)
        {
            _context.CourseInstallments.AddRange(listModels);
            await _context.SaveChangesAsync();
            return listModels;
        }
        public async Task<bool> DeleteMultipleAsync(IEnumerable<long> ids)
        {
            try
            {
                var itemsToDelete = await _context.CourseInstallments.Where(item => ids.Contains(item.Id)).ToListAsync();
                _context.CourseInstallments.RemoveRange(itemsToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<CourseInstallments> CreateModelAsync(CourseInstallments entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.CourseInstallments.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<CourseInstallments> DeleteModelAsync(CourseInstallments entity)
        {
            _context.ChangeTracker.Clear();
            _context.CourseInstallments.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CourseInstallments>> GetAllAsync()
        {
            return await _context.CourseInstallments.ToListAsync();
        }

        public async Task<CourseInstallments> GetByIdAsync(long id)
        {
            return await _context.CourseInstallments.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<CourseInstallments> UpdateModelAsync(CourseInstallments entity)
        {
            entity.UpdateDomain(entity.StudentId, entity.InstallmentPrice, entity.PaymentDate, entity.DueDate, entity.InstallmentStatus, entity.PaymentMethod);
            entity.CreationData = _context.CourseInstallments.FirstAsync(x => x.Id == entity.Id).Result.CreationData;

            _context.ChangeTracker.Clear();
            _context.CourseInstallments.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
