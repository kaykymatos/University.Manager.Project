using FluentValidation;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Financial.Application.Validation
{
    public class CourseInstallmentsRequestDTOValidation : AbstractValidator<CourseInstallmentsRequestDTO>
    {
        public CourseInstallmentsRequestDTOValidation()
        {
            RuleFor(x => x.StudentId)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Student Id");

            RuleFor(x => x.InstallmentPrice)
               .GreaterThan(0).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan)
                .WithName("Installment Price");

            RuleFor(x => x.InstallmentPrice)
               .LessThan(999999).WithMessage(BaseValidationErrorMessages.FieldNumberMustBeLessThan)
                .WithName("Installment Price");

            RuleFor(x => x.DueDate)
                .Must(x => x > DateTime.Today)
                .WithMessage("The filed Due Date must bee greater today!")
                .WithName("Due Date");

            RuleFor(x => x.InstallmentStatus)
             .Must(BeAValidEnumValue)
             .WithMessage("Invalid Installment Status").WithName("Installment Status");

            RuleFor(x => x.PaymentMethod)
            .Must(BeAValidEnumValue)
            .WithMessage("Invalid Payment Method").WithName("Payment Method");
        }
        private bool BeAValidEnumValue<TEnum>(TEnum value)
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}
