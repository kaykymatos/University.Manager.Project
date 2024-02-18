using FluentValidation;
using University.Manager.Project.Student.Api.Validation.ErrorMessages;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Student.Api.Validation
{
    public class StudentEntityRequestDTOValidation : AbstractValidator<StudentEntityRequestDTO>
    {
        public StudentEntityRequestDTOValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Name");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Surname");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage(BaseValidationErrorMessages.FieldEmail)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .WithName("Email");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(8).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(100).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Password");

            RuleFor(x => x.RegisterCode)
               .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Register Code");

            RuleFor(x => x.CourseId)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Course Id");
        }
    }
}
