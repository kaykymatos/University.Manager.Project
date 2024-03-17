using University.Manager.Project.Student.Domain.Validation;

namespace University.Manager.Project.Student.Domain.Entities
{
    public class StudentEntity : Entity
    {
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }
        public long StudentId { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(long id, string registerCode, long courseId, long studentId)
        {

            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(registerCode, courseId, studentId);
        }

        public void UpdateDomain(string registerCode, long courseId, long studentId)
        {
            ValidationDomain(registerCode, courseId, studentId);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string registerCode, long courseId, long studentId)
        {
            DomainExceptionValidation.When(registerCode.Length < 3,
                "Invalid Register code, Register code is too short, minimum 3 characters!");
            DomainExceptionValidation.When(registerCode.Length > 200,
                "Invalid Register code, Register code is too long, maximum 200 characters!");
            RegisterCode = registerCode;

            DomainExceptionValidation.When(courseId <= 0,
                "Invalid Course Id, Course Id is required!");
            CourseId = courseId;

            DomainExceptionValidation.When(studentId <= 0,
                "Invalid Student Id, Student Id is required!");
            StudentId = studentId;

        }

    }
}
