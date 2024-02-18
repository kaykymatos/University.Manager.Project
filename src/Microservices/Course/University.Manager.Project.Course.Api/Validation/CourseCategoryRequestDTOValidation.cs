using FluentValidation;
using University.Manager.Project.Course.Api.Validation.ErrorMessages;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Course.Api.Validation
{
    public class CourseCategoryRequestDTOValidation : AbstractValidator<CourseCategoryRequestDTO>
    {
        public CourseCategoryRequestDTOValidation()
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
        }
    }
}
