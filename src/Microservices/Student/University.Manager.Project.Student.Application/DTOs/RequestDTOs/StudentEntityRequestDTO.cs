namespace University.Manager.Project.Student.Application.DTOs.RequestDTOs
{
    public class StudentEntityRequestDTO
    {
        public StudentEntityRequestDTO(long id, string registerCode, long courseId)
        {
            Id = id;
            RegisterCode = registerCode;
            CourseId = courseId;
        }
        public StudentEntityRequestDTO()
        {

        }
        public long Id { get; set; }
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
