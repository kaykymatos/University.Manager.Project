using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Course.Application.Test.Builder;
using University.Manager.Project.Course.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Course.Application.Test
{
    public class CourseCategoryRequestDTOTests
    {
       
        private readonly CourseCategoryRequestDTOValidation _validator;
        private readonly CourseCategoryRequestDTOBuilder _builder;
        public CourseCategoryRequestDTOTests()
        {

            _builder = new CourseCategoryRequestDTOBuilder();
            _validator = new ServiceCollection()
                .AddTransient<CourseCategoryRequestDTOValidation>()
                .BuildServiceProvider().GetService<CourseCategoryRequestDTOValidation>();
        }
        [Fact]
        public async Task CreateCourseCategory_WithValidParameters_ResultObjectValidState()
        {
            CourseCategoryRequestDTO instance = _builder.Build();
            ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateCourseCategory_ShortName_DomainExceptionShortName(string name)
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Name=name).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Name").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateCourseCategory_NullName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Name = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Name = string.Empty).Build();

            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyStringName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Name = "").Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Theory]
        [InlineData("a")]
        [InlineData("as")]
        public async Task CreateCourseCategory_ShortDescription_DomainExceptionShortDescription(string description)
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Description = description).Build();
                
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Description").Replace("{MinLength}", "3")));

        }
        [Fact]
        public async Task CreateCourseCategory_NullDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model =_builder.With(x => x.Description = null).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Description = string.Empty).Build();
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyStringDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Description = "").Build(); 
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_LongName_DomainExceptionLongName()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Name = "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course cs").Build();
            
            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Name").Replace("{MaxLength}", "200")));

        }
        [Fact]
        public async Task CreateCourseCategory_LongDescription_DomainExceptionLongDescription()
        {
            CourseCategoryRequestDTO model = _builder.With(x => x.Description = "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course cs").Build();

            ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Description").Replace("{MaxLength}", "200")));
        }
    }
}