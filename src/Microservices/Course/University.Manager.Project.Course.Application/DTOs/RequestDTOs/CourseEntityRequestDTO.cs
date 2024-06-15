namespace University.Manager.Project.Course.Application.DTOs.RequestDTOs
{
    public class CourseEntityRequestDTO
    {
        public CourseEntityRequestDTO(long id, string name, string description, float workload, decimal totalValue, long categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Workload = workload;
            TotalValue = totalValue;
            CourseCategoryId = categoryId;
        }
        public CourseEntityRequestDTO()
        {

        }
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Workload { get; set; }
        public decimal TotalValue { get; set; }
        public long CourseCategoryId { get; set; }
    }
}
