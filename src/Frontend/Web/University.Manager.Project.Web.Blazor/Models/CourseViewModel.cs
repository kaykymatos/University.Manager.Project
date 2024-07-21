namespace University.Manager.Project.Web.Blazor.Models
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; } = DateTime.Now;
        public DateTime UpdatedData { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Workload { get; set; }
        public decimal TotalValue { get; set; }
        public long CourseCategoryId { get; set; }
        public CourseCategoryViewModel CourseCategory { get; set; }

    }
}
