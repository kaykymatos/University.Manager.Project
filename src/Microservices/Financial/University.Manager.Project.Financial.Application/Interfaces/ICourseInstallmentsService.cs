using University.Manager.Project.Financial.Application.DTOs;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Domain.Entities;

namespace University.Manager.Project.Financial.Application.Interfaces
{
    public interface ICourseInstallmentsService : IBaseService<CourseInstallmentsDTO, CourseInstallmentsRequestDTO>
    {
        Task<IEnumerable<CourseInstallments>> CreateMany(List<CourseInstallments> listModels);
    }
}
