using University.Manager.Project.Course.Domain.Validation;

namespace University.Manager.Project.Course.Domain.Entities
{
    public class CourseCategory : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<CourseEntity> Courses { get; set; }
        public CourseCategory()
        {

        }
        public CourseCategory(long id, string name, string description)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value!");
            Id = id;
            ValidationDomain(name, description);
        }
        public CourseCategory(string name, string description)
        {
            ValidationDomain(name, description);
        }
        public void UpdateCourseCategory(string name, string description)
        {
            ValidationDomain(name, description);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string name, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Name, Name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 100,
                "Invalid Name, Name is too long, maximum 200 characters!");
            Name = name;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
                "Invalid Description, Description is required!");
            DomainExceptionValidation.When(description.Length < 3,
                "Invalid Description, Description is too short, minimum 3 characters!");
            DomainExceptionValidation.When(description.Length > 100,
                "Invalid Description, Description is too long, maximum 200 characters!");
            Description = description;
        }

    }
}
