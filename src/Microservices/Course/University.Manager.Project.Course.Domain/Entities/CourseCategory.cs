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
        public CourseCategory(long id, string name, string descrition)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidationDomain(name, descrition);
        }
        public CourseCategory(string name, string descrition)
        {
            ValidationDomain(name, descrition);
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

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Descrition, Descrition is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Descrition, Descrition is too short, minimum 3 characters!");
            Name = name;
            Description = description;
        }

    }
}
