namespace University.Manager.Project.Student.Application.DTOs.RequestDTOs
{
    public class StudentEntityRequestDTO
    {
        public StudentEntityRequestDTO(long id, string name, string surName, string registerCode, long courseId, string email, string password)
        {
            Id = id;
            Name = name;
            SurName = surName;
            RegisterCode = registerCode;
            CourseId = courseId;
            Email = email;
            Password = password;
        }
        public StudentEntityRequestDTO()
        {

        }
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
    }
}
