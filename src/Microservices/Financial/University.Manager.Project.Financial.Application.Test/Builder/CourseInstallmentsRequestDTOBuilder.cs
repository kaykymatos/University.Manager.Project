using FizzWare.NBuilder;
using University.Manager.Project.Financial.Application.DTOs.Enums;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;

namespace University.Manager.Project.Financial.Application.Test.Builder
{
    public class CourseInstallmentsRequestDTOBuilder : BuilderBase<CourseInstallmentsRequestDTO>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<CourseInstallmentsRequestDTO>.CreateNew()
                .With(x => x.InstallmentPrice = 1000)
                .With(x => x.InstallmentStatus = EInstallmentStatus.Paid)
                .With(x => x.StudentId = 1)
                .With(x => x.DueDate = DateTime.Today.AddDays(2))
                .With(x => x.PaymentDate = DateTime.Today)
                .With(x => x.PaymentMethod = EPaymentMethod.CreditCard);
        }
    }
}
