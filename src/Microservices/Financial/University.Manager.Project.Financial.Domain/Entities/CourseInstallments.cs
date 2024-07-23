using University.Manager.Project.Financial.Domain.Entities.Enums;
using University.Manager.Project.Financial.Domain.Interfaces;
using University.Manager.Project.Financial.Domain.Validation;

namespace University.Manager.Project.Financial.Domain.Entities
{
    public class CourseInstallments : Entity
    {
        public long StudentId { get; set; }
        public decimal InstallmentPrice { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public EInstallmentStatus InstallmentStatus { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }

        public CourseInstallments()
        {

        }

        public CourseInstallments(long id, long studentId, decimal installmentPrice, DateTime? paymentDate, DateTime dueDate, EInstallmentStatus installmentStatus, EPaymentMethod paymentMethod)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(studentId, installmentPrice, paymentDate, dueDate, installmentStatus, paymentMethod);
        }
        public override void UpdateDomain(IBaseEntity entity)
        {
            if (entity is CourseInstallments instalment)
            {
                ValidationDomain(instalment.StudentId, instalment.InstallmentPrice, instalment.PaymentDate, instalment.DueDate, instalment.InstallmentStatus, instalment.PaymentMethod);
            }
            entity.UpdatedData = DateTime.Now;
        }

        public void ValidationDomain(long studentId, decimal installmentPrice, DateTime? paymentDate, DateTime dueDate, EInstallmentStatus installmentStatus, EPaymentMethod paymentMethod)
        {
            DomainExceptionValidation.When(studentId <= 0,
               "Invalid Student Id, Student Id is required!");
            StudentId = studentId;

            DomainExceptionValidation.When(installmentPrice <= 0,
               "Invalid Installment price, Installment price is required!");
            DomainExceptionValidation.When(installmentPrice >= 999999,
                "Invalid Installment price, Installment price is too long, maximum $999998.00!");
            InstallmentPrice = installmentPrice;

            if (paymentDate.HasValue)
            {
                DomainExceptionValidation.When(paymentDate < DateTime.Today,
                "Invalid Payment Date, Payment Date cannot be in the past!");
                PaymentDate = paymentDate;
            }

            DomainExceptionValidation.When(dueDate < DateTime.Today,
                "Invalid Due Date, Due Date cannot be in the past!");
            DueDate = dueDate;

            DomainExceptionValidation.When(installmentStatus != EInstallmentStatus.Pending &&
                                           installmentStatus != EInstallmentStatus.Paid &&
                                           installmentStatus != EInstallmentStatus.Overdue &&
                                           installmentStatus != EInstallmentStatus.Cancelled &&
                                           installmentStatus != EInstallmentStatus.Refunded &&
                                           installmentStatus != EInstallmentStatus.Other,
                "Invalid Installment Status, Invalid status provided!");
            InstallmentStatus = installmentStatus;

            DomainExceptionValidation.When(paymentMethod != EPaymentMethod.CreditCard &&
                                           paymentMethod != EPaymentMethod.DebitCard &&
                                           paymentMethod != EPaymentMethod.BankTransfer &&
                                           paymentMethod != EPaymentMethod.PayPal &&
                                           paymentMethod != EPaymentMethod.Cash &&
                                           paymentMethod != EPaymentMethod.Check &&
                                           paymentMethod != EPaymentMethod.Other,
                "Invalid Payment Method, Invalid method provided!");
            PaymentMethod = paymentMethod;

        }
    }
}
