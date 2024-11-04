using FluentValidation;
using University.Manager.Project.Financial.Application.DTOs;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Application.Interfaces;

namespace University.Manager.Project.Financial.Api.Endpoints.V1
{
    public class FinancialEndpoints : BaseEndpoints<CourseInstallmentsDTO, CourseInstallmentsRequestDTO, ICourseInstallmentsService, IValidator<CourseInstallmentsRequestDTO>>
    {
        protected override string BaseRoute => "api/v1/financial";
    }

}
