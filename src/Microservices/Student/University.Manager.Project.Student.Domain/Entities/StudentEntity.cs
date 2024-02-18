using University.Manager.Project.Student.Domain.Validation;

namespace University.Manager.Project.Student.Domain.Entities
{
    public class StudentEntity : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passowrd { get; set; } = string.Empty;
        public string RegisterCode { get; set; } = string.Empty;
        public long CourseId { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(long id, string name, string surName, string registerCode, long courseId, string email, string password)
        {

            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(name, surName, registerCode, courseId, email, password);
        }

        public void UpdateDomain(string name, string surName, string registerCode, long courseId, string email, string password)
        {
            ValidationDomain(name, surName, registerCode, courseId, email, password);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string name, string surName, string registerCode, long courseId, string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Name, Name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid Name, Name is too long, maximum 200 characters!");
            Name = name;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(surName),
                "Invalid Surname, Surname is required!");
            DomainExceptionValidation.When(surName.Length < 3,
                "Invalid Surname, Surname is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid Surname, Surname is too long, maximum 200 characters!");
            SurName = surName;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(surName),
                "Invalid Register code, Register code is required!");
            DomainExceptionValidation.When(registerCode.Length < 3,
                "Invalid Register code, Register code is too short, minimum 3 characters!");
            DomainExceptionValidation.When(registerCode.Length > 200,
                "Invalid Register code, Register code is too long, maximum 200 characters!");
            RegisterCode = registerCode;

            DomainExceptionValidation.When(courseId <= 0,
                "Invalid Course Id, Course Id is required!");
            CourseId = courseId;


            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email),
                "Invalid Email, Email is required!");
            DomainExceptionValidation.When(email.Length < 3,
                "Invalid Email, Email is too short, minimum 3 characters!");
            DomainExceptionValidation.When(email.Length > 200,
                "Invalid Email, Email is too long, maximum 200 characters!");
            Email = email;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(password),
                "Invalid Password, Password is required!");
            DomainExceptionValidation.When(password.Length < 8,
                "Invalid Password, Password is too short, minimum 8 characters!");
            DomainExceptionValidation.When(password.Length > 400,
                "Invalid Password, Password is too long, maximum 400 characters!");
            Passowrd = password;
        }

    }
}
