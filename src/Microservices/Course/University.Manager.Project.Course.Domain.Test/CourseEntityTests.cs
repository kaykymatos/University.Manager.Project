using FluentAssertions;
using University.Manager.Project.Course.Domain.Entities;
using University.Manager.Project.Course.Domain.Validation;

namespace University.Manager.Project.Course.Domain.Test
{
    public class CourseEntityTests
    {
        [Fact]
        public void CreateCourseEntity_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new CourseEntity(1, "Course", "Course Description", 10, 1000);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCourseEntity_NavigateIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            new CourseEntity(-1, "Course", "Course Description", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void CreateCourseEntity_ShortName_DomainExceptionShortName(string name)
        {
            Action action = () =>
            new CourseEntity(1, name, "Course Description", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateCourseEntity_NullName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseEntity(1, null, "Course Description", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Fact]
        public void CreateCourseEntity_EmptyName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseEntity(1, string.Empty, "Course Description", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Fact]
        public void CreateCourseEntity_EmptyStringName_DomainExceptionNameIsRequired()
        {
            Action action = () =>
            new CourseEntity(1, "", "Course Description", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required!");
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void CreateCourseEntity_ShortDescription_DomainExceptionShortDescription(string description)
        {
            Action action = () =>
            new CourseEntity(1, "Course", description, 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateCourseEntity_NullDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
            new CourseEntity(1, "Course", null, 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Fact]
        public void CreateCourseEntity_EmptyDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
            new CourseEntity(1, "Course", string.Empty, 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Fact]
        public void CreateCourseEntity_EmptyStringDescription_DomainExceptionDescriptionIsRequired()
        {
            Action action = () =>
           new CourseEntity(1, "Course", "", 10, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required!");
        }
        [Theory]
        [InlineData(-1f)]
        [InlineData(-2f)]
        [InlineData(-3f)]
        [InlineData(-10f)]
        [InlineData(-20f)]
        [InlineData(-30f)]
        [InlineData(0f)]
        [InlineData(0.1f)]
        [InlineData(0.2f)]
        [InlineData(0.3f)]
        [InlineData(0.4f)]
        [InlineData(0.5f)]
        [InlineData(0.9f)]
        public void CreateCourseEntity_InvalidWorkload_DomainExceptionInvalidWorkload(float workLoad)
        {
            Action action = () =>
           new CourseEntity(1, "Course", "Course", workLoad, 1000);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Workload, Workload is too short, minimum 1 hour!");
        }
        [Fact]
        public void CreateCourseEntity_LessTotalValue_DomainExceptionInvalidTotalValue()
        {
            Action action = () =>
           new CourseEntity(1, "Course", "Course", 1000, 0);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Total Value, Total Value is required!");
        }
        [Theory]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.3)]
        [InlineData(0.4)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(90)]
        [InlineData(999)]
        public void CreateCourseEntity_LessTotalValue_DomainExceptionTotalValueMustBeGreater(decimal totalValue)
        {
            Action action = () =>
           new CourseEntity(1, "Course", "Course", 1000, totalValue);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Total Value, Total Value must be greater than $999.00!");
        }
        [Theory]
        [InlineData(9999999)]
        [InlineData(99999999)]
        [InlineData(999999999)]
        [InlineData(1000000000)]
        [InlineData(10000000000)]
        public void CreateCourseEntity_GreaterTotalValue_DomainExceptionTotalValueMustLessThan(decimal totalValue)
        {
            Action action = () =>
           new CourseEntity(1, "Course", "Course", 1000, totalValue);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Total Value, Total Value is too long, maximum $9999998.00!");
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