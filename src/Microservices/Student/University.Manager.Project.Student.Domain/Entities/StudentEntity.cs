using University.Manager.Project.Student.Domain.Interfaces;
using University.Manager.Project.Student.Domain.Validation;

namespace University.Manager.Project.Student.Domain.Entities
{
    public class StudentEntity : Entity
    {
        public string RegisterCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long CourseId { get; set; }


        public StudentEntity()
        {

        }

        public StudentEntity(long id, string registerCode, long courseId, string name, string email)
        {

            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(registerCode, courseId, name, email);
        }

        private void ValidationDomain(string registerCode, long courseId, string name, string email)
        {
            DomainExceptionValidation.When(registerCode.Length < 3,
                "Invalid Register code, Register code is too short, minimum 3 characters!");
            DomainExceptionValidation.When(registerCode.Length > 200,
                "Invalid Register code, Register code is too long, maximum 200 characters!");
            RegisterCode = registerCode;

            DomainExceptionValidation.When(courseId <= 0,
                "Invalid Course Id, Course Id is required!");
            CourseId = courseId;


            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Register code, Name is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid Register code, Name is too long, maximum 200 characters!");
            Name = name;


            DomainExceptionValidation.When(email.Length < 3,
                "Invalid Register code, Email is too short, minimum 3 characters!");
            DomainExceptionValidation.When(email.Length > 200,
                "Invalid Register code, Email is too long, maximum 200 characters!");
            Email = email;
        }

        public override void UpdateDomain(IBaseEntity entity)
        {
            if (entity is StudentEntity studentEntity)
            {
                ValidationDomain(studentEntity.RegisterCode, studentEntity.CourseId, studentEntity.Name, studentEntity.Email);
            }
            entity.UpdatedData = DateTime.Now;
        }
    }
}
