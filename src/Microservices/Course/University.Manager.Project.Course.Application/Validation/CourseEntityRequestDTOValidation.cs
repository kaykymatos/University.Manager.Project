using FluentValidation;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Validation.ErrorMessages;

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
                .WithName("Name");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(BaseValidationErrorMessages.FieldNull)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .WithName("Description");

            RuleFor(x => x.Workload)
                .GreaterThan(0.9f).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Workload");

            RuleFor(x => x.TotalValue)
                .GreaterThan(999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .LessThan(9999999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeLessThan)
                .WithName("Total Value");
        }
    }
}
