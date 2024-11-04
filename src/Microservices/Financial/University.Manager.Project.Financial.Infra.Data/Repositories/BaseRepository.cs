using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Financial.Domain.Interfaces;
using University.Manager.Project.Financial.Infra.Data.Context;

namespace University.Manager.Project.Financial.Infra.Data.Repositories
{
    public class BaseRepository<T>(ApplicationContext context) where T : class, IBaseEntity
    {
        private readonly ApplicationContext _context = context;

        public virtual async Task<bool> DeleteMultipleAsync(IEnumerable<long> ids)
        {
            try
            {
                var itemsToDelete = await _context.Set<T>().Where(item => ids.Contains(item.Id)).ToListAsync();
                _context.Set<T>().RemoveRange(itemsToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public virtual async Task<T> CreateModelAsync(T entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> DeleteModelAsync(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);


        public virtual async Task<T> UpdateModelAsync(T entity)
        {
            entity.UpdateDomain(entity);
            entity.CreationData = _context.Set<T>().FirstAsync(x => x.Id == entity.Id).Result.CreationData;

            _context.ChangeTracker.Clear();
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
