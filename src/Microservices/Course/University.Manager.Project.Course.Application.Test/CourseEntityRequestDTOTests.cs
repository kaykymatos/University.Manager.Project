using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Course.Application.Test.Builder;
using University.Manager.Project.Course.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Course.Application.Test
{
    public class CourseEntityRequestDTORequestDTOTests
    {
        private readonly CourseEntityRequestDTOValidation _validator;
        private readonly CourseEntityRequestDTOBuilder _builder;
        public CourseEntityRequestDTORequestDTOTests()
        {
            _builder = new CourseEntityRequestDTOBuilder();
            _validator = new ServiceCollection()
                .AddTransient<CourseEntityRequestDTOValidation>()
                .BuildServiceProvider().GetService<CourseEntityRequestDTOValidation>();

        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_WithValidParameters_ResultObjectValidState()
        {
            CourseEntityRequestDTO model = _builder.Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.True(validation.IsValid);
        }


        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateCourseEntityRequestDTO_ShortName_DomainExceptionShortName(string name)
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Name = name).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Name").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_NullName_DomainExceptionNameIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Name = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_EmptyName_DomainExceptionNameIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Name = string.Empty).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_EmptyStringName_DomainExceptionNameIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Name = "").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateCourseEntityRequestDTO_ShortDescription_DomainExceptionShortDescription(string description)
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Description = description).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Description").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_NullDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Description = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_EmptyDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Description = string.Empty).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_EmptyStringDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Description = "").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

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
        public async Task CreateCourseEntityRequestDTO_InvalidWorkload_DomainExceptionInvalidWorkload(float workLoad)
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Workload = workLoad).Build();

            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Workload").Replace("{ComparisonValue}", "0,9")));
        }
        [Fact]
        public async Task CreateCourseEntityRequestDTO_LessTotalValue_DomainExceptionInvalidTotalValue()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.TotalValue = 0).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);

            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Total Value").Replace("{ComparisonValue}", "999")));
        }
        [Theory]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.3)]
        [InlineData(0.4)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        public async Task CreateCourseEntityRequestDTO_LessTotalValue_DomainExceptionTotalValueMustBeGreater(decimal totalValue)
        {
            CourseEntityRequestDTO model = _builder.With(x => x.TotalValue = totalValue).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Total Value").Replace("{ComparisonValue}", "999")));

        }
        [Theory]
        [InlineData(9999999)]
        [InlineData(99999999)]
        [InlineData(999999999)]
        [InlineData(1000000000)]
        [InlineData(10000000000)]
        public async Task CreateCourseEntityRequestDTO_GreaterTotalValue_DomainExceptionTotalValueMustLessThan(decimal totalValue)
        {
            CourseEntityRequestDTO model = _builder.With(x => x.TotalValue = totalValue).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeLessThan.Replace("{PropertyName}", "Total Value").Replace("{ComparisonValue}", "9999999")));
        }
        [Fact]
        public async Task CreateCourseCategory_LongName_DomainExceptionLongName()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Name = "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course csc").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Name").Replace("{MaxLength}", "200")));
        }
        [Fact]
        public async Task CreateCourseCategory_LongDescription_DomainExceptionLongDescription()
        {
            CourseEntityRequestDTO model = _builder.With(x => x.Description = "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course csc").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Description").Replace("{MaxLength}", "200")));
        }

    }
}
