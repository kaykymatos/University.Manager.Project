using Microsoft.EntityFrameworkCore;
using University.Manager.Project.Order.Domain.Entities;
using University.Manager.Project.Order.Domain.Interfaces;
using University.Manager.Project.Order.Infra.Data.Context;

namespace University.Manager.Project.Order.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMultipleAsync(IEnumerable<long> ids)
        {
            try
            {
                var itemsToDelete = await _context.Orders.Where(item => ids.Contains(item.Id)).ToListAsync();
                _context.Orders.RemoveRange(itemsToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<OrderEntity> CreateModelAsync(OrderEntity entity)
        {
            entity.CreationData = DateTime.Now;
            entity.UpdatedData = DateTime.Now;
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderEntity> DeleteModelAsync(OrderEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderEntity> GetByIdAsync(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderEntity> UpdateModelAsync(OrderEntity entity)
        {
            entity.UpdateDomain(entity.Title, entity.Message, entity.Attachment, entity.OrderType, entity.UserId);
            entity.CreationData = _context.Orders.FirstAsync(x => x.Id == entity.Id).Result.CreationData;
            _context.ChangeTracker.Clear();
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
