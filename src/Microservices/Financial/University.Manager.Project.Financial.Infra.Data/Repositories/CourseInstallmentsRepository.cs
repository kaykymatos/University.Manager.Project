using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
