using University.Manager.Project.Financial.Domain.Entities;

namespace University.Manager.Project.Financial.Domain.Interfaces
{
    public interface ICourseInstallmentsRepository : IBaseRepository<CourseInstallments>
    {
        Task<IEnumerable<CourseInstallments>> CreateMany(List<CourseInstallments> listModels);
    }
}
