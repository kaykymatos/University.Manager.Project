using University.Manager.Project.Financial.Application.DTOs.Enums;
using University.Manager.Project.Financial.Application.Interfaces;

namespace University.Manager.Project.Financial.Application.DTOs.RequestDTOs
{
    public class CourseInstallmentsRequestDTO : IBaseModel
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public decimal InstallmentPrice { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public EInstallmentStatus InstallmentStatus { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
