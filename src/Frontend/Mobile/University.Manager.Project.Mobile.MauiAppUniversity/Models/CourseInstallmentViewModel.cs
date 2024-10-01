using University.Manager.Project.Mobile.MauiAppUniversity.Models.Enums;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Models
{
    public class CourseInstallmentViewModel : IBaseModel
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public decimal InstallmentPrice { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        public EInstallmentStatus InstallmentStatus { get; set; }
        public EPaymentMethod PaymentMethod { get; set; }
        public Dictionary<string, object> ToDictionary()
        {
            throw new NotImplementedException();
        }
    }
}
