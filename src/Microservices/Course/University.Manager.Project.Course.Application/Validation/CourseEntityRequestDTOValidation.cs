using FluentValidation;
using University.Manager.Project.Course.Api.Validation.ErrorMessages;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Course.Application.Validation
{
    public class CourseEntityRequestDTOValidation : AbstractValidator<CourseEntityRequestDTO>
    {
        public CourseEntityRequestDTOValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Name");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Description");

            RuleFor(x => x.Workload)
                .GreaterThan(0.9f).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Workload");

            RuleFor(x => x.TotalValue)
                .GreaterThan(1).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .LessThan(9999999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeLessThan)
                .WithName("Total Value");
        }
    }
}
