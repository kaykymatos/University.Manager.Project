namespace University.Manager.Project.Course.Application.DTOs.RequestDTOs
{
    public class CourseEntityRequestDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Workload { get; set; }
        public decimal TotalValue { get; set; }
        public long CourseCategoryId { get; set; }
    }
}
