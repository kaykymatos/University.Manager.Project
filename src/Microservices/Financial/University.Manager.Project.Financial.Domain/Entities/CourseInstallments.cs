using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Manager.Project.Financial.Domain.Validation;

namespace University.Manager.Project.Financial.Domain.Entities
{
    public class CourseInstallments : Entity
    {
        public long StudentId { get; set; }
        public long InstallmentsNumber { get; set; }
        public decimal InstallmentPrice { get; set; }
        public CourseInstallments(long id, long studentId, long installmentsNumber, decimal installmentsPrice)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(studentId, installmentsNumber, installmentsPrice);
        }
        public CourseInstallments()
        {
                
        }
        public void UpdateDomain(long studentId, long installmentsNumber, decimal installmentsPrice)
        {
            ValidationDomain(studentId, installmentsNumber, installmentsPrice);
            UpdatedData = DateTime.Now;
        }
        public void ValidationDomain(long studentId, long installmentsNumber, decimal installmentPrice)
        {
            DomainExceptionValidation.When(studentId <= 0,
               "Invalid Student Id, Student Id is required!");
            StudentId = studentId;
            DomainExceptionValidation.When(installmentsNumber <= 0,
               "Invalid installments number, installments number is required!");
            InstallmentsNumber = installmentsNumber;

            DomainExceptionValidation.When(installmentPrice <= 0,
               "Invalid Installment price, Installment price is required!");
            DomainExceptionValidation.When(installmentPrice >= 999999,
                "Invalid Installment price, Installment price is too long, maximum $999998.00!");
            InstallmentPrice = installmentPrice;
        }
    }
}
