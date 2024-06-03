
using FluentAssertions;
using University.Manager.Project.Student.Domain.Entities;
using University.Manager.Project.Student.Domain.Validation;
namespace University.Manager.Project.Student.Domain.Test
{
    public class StudentEntityTests
    {

        [Fact]
        public void CreateStudentEntity_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new StudentEntity(1, "1233", 1, "Student", "student@student.com");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateStudentEntity_WithCourseIdLess_ResultObjectInvalidCourseIMustBeGreaterThan()
        {
            Action action = () => new StudentEntity(1, "1233", 0, "Student", "student@student.com");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Course Id, Course Id is required!");
        }
        [Fact]
        public void CreateStudentEntity_WithRegisterCodeLess_ResultObjectInvalidRegisterCodeMustBeGreaterThan()
        {
            Action action = () => new StudentEntity(1, "12", 1, "Student", "student@student.com");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Register code, Register code is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateStudentEntity_WithRegisterCodeGreater_ResultObjectInvalidRegisterCodeMustBeLessThan()
        {
            Action action = () => new StudentEntity(1, "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111", 1, "Student", "student@student.com");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Register code, Register code is too long, maximum 200 characters!");
        }
    }
}