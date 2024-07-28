using FluentValidation;
using University.Manager.Project.Student.Application.DTOs;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Interfaces;

namespace University.Manager.Project.Student.Api.Endpoints.V1
{
    public class StudentEndpoints : BaseEndpoints<StudentEntityDTO, StudentEntityRequestDTO, IStudentService, IValidator<StudentEntityRequestDTO>>
    {
        protected override string BaseRoute => "api/v1/student";
    }

}
