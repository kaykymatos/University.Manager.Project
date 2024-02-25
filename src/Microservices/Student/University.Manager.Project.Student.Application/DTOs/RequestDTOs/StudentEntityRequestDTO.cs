namespace University.Manager.Project.Student.Application.DTOs.RequestDTOs
{
    public class StudentEntityRequestDTO
    {
        public StudentEntityRequestDTO(long id, string registerCode, long courseId, long studentId)
        {
            Id = id;
            StudentId = studentId;
            RegisterCode = registerCode;
            CourseId = courseId;
        }
        public StudentEntityRequestDTO()
        {

        }
        public long Id { get; set; }
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public long StudentId { get; set; }
    }
}
