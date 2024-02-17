using FluentValidation;
using University.Manager.Project.Course.Api.Validation.ErrorMessages;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;

namespace University.Manager.Project.Course.Api.Validation
{
    public class CourseEntityDTOValidation : AbstractValidator<CourseEntityRequestDTO>
    {
        private readonly ICourseCategoryService _service;
        public CourseEntityDTOValidation(ICourseCategoryService service)
        {
            _service = service;
            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Name");

            RuleFor(x => x.Description)
                .MinimumLength(3).WithMessage(BaseValidationErrorMessages.FieldMinLenght)
                .MaximumLength(200).WithMessage(BaseValidationErrorMessages.FieldMaxLenght)
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage(BaseValidationErrorMessages.FieldWithSpecialCharacters)
                .WithName("Description");

            RuleFor(x => x.Workload)
                .GreaterThan(0.9f).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Workload");

            RuleFor(x => x.TotalValue)
                .GreaterThan(999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .LessThan(9999999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeLessThan)
                .WithName("Total Value");

            RuleFor(x => x.CourseCategoryId)
                .Must(VerifyCategoryId).WithMessage("Category Id not found!")
                .WithName("Category Id");
        }
        private bool VerifyCategoryId(long categoryId) => _service.GetByIdAsync(categoryId).Result != null;
    }
}
