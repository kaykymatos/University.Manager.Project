using FluentValidation;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Student.Application.Validation
{
    public class StudentEntityRequestDTOValidation : AbstractValidator<StudentEntityRequestDTO>
    {
        public StudentEntityRequestDTOValidation()
        {

            RuleFor(x => x.RegisterCode)
               .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Register Code");

            RuleFor(x => x.CourseId)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Course Id");

            RuleFor(x => x.StudentId)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Student Id");
        }
    }
}
