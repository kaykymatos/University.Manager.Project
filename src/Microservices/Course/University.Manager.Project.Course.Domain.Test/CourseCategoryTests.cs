using FluentAssertions;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Validation;

namespace University.Manager.Project.Course.Domain.Test
{
    public class CourseCategoryTests
    {
        [Fact]
        public void CreateCourseCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new CourseCategory(1, "Category Name", "Category Description");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCourseCategory_NavigateIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            new CourseCategory(-1, "Category Name", "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void CreateCourseCategory_ShortName_DomainExceptionShortName(string name)
        {
            Action action = () =>
            new CourseCategory(1, name, "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateCourseCategory_NullName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, null, "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Fact]
        public void CreateCourseCategory_EmptyName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, string.Empty, "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Fact]
        public void CreateCourseCategory_EmptyStringName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, "", "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("as")]
        public void CreateCourseCategory_ShortDescription_DomainExceptionShortDescription(string description)
        {
            Action action = () =>
            new CourseCategory(1, "Category", description);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateCourseCategory_NullDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, "Category", null);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Fact]
        public void CreateCourseCategory_EmptyDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, "Category", string.Empty);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Fact]
        public void CreateCourseCategory_EmptyStringDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
            new CourseCategory(1, "Category", "");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Fact]
        public void CreateCourseCategory_LongName_DomainExceptionLongName()
        {
            Action action = () =>
            new CourseCategory(1, "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course c", "Category Description");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too long, maximum 200 characters!");
        }
        [Fact]
        public void CreateCourseCategory_LongDescription_DomainExceptionLongDescription()
        {
            Action action = () =>
            new CourseCategory(1, "Course category", "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course c");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is too long, maximum 200 characters!");
        }
    }
}