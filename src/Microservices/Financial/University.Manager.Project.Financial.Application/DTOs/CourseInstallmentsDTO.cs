using University.Manager.Project.Financial.Application.DTOs.Enums;

namespace University.Manager.Project.Financial.Application.DTOs
{
    public class CourseInstallmentsDTO
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public decimal InstallmentPrice { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public EInstallmentStatus InstallmentStatus { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }


    }
}
