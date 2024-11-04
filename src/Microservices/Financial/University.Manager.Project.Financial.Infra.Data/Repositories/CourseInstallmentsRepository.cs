using University.Manager.Project.Financial.Domain.Entities;
using University.Manager.Project.Financial.Domain.Interfaces;
using University.Manager.Project.Financial.Infra.Data.Context;

namespace University.Manager.Project.Financial.Infra.Data.Repositories
{
    public class CourseInstallmentsRepository : BaseRepository<CourseInstallments>, ICourseInstallmentsRepository
    {

        private readonly ApplicationContext _context;
        public CourseInstallmentsRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseInstallments>> CreateMany(List<CourseInstallments> listModels)
        {
            try
            {
                _context.CourseInstallments.AddRange(listModels);
                await _context.SaveChangesAsync();
                return listModels;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
