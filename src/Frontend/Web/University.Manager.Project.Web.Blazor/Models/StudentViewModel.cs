namespace University.Manager.Project.Web.Blazor.Models
{
    public class StudentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public decimal TotalValue { get; set; }
        public float Workload { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
