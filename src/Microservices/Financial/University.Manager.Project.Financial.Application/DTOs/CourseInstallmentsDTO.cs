namespace University.Manager.Project.Financial.Application.DTOs
{
    public class CourseInstallmentsDTO
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public long StudentId { get; set; }
        public decimal InstallmentPrice { get; set; }

    }
}
