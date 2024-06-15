namespace University.Manager.Project.Student.Application.DTOs
{
    public class StudentEntityDTO
    {
        public long Id { get; set; }
        public string RegisterCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long CourseId { get; set; }

        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
    }
}
