using University.Manager.Project.Course.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Course.Application.Test
{
    public class CourseCategoryRequestDTOTests
    {
        private readonly CourseCategoryRequestDTOValidation _validator;
        public CourseCategoryRequestDTOTests()
        {
            _validator = new CourseCategoryRequestDTOValidation();
        }
        [Fact]
        public async Task CreateCourseCategory_WithValidParameters_ResultObjectValidState()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Category Name", "Category Description");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.True(validation.IsValid);
        }
        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public async Task CreateCourseCategory_ShortName_DomainExceptionShortName(string name)
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, name, "Category Description");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Name").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateCourseCategory_NullName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, null, "Category Description");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, string.Empty, "Category Description");

            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyStringName_DomainExceptionNameIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "", "Category Description");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Name")));

        }
        [Theory]
        [InlineData("a")]
        [InlineData("as")]
        public async Task CreateCourseCategory_ShortDescription_DomainExceptionShortDescription(string description)
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Category", description);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Description").Replace("{MinLength}", "3")));

        }
        [Fact]
        public async Task CreateCourseCategory_NullDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Category", null);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Category", string.Empty);
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_EmptyStringDescription_DomainExceptionDescriptionIsRequired()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Category", "");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Description")));

        }
        [Fact]
        public async Task CreateCourseCategory_LongName_DomainExceptionLongName()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course cs", "Category Description");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Name").Replace("{MaxLength}", "200")));

        }
        [Fact]
        public async Task CreateCourseCategory_LongDescription_DomainExceptionLongDescription()
        {
            CourseCategoryRequestDTO model = new CourseCategoryRequestDTO(1, "Course category", "Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course category Course cs");
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(model);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Description").Replace("{MaxLength}", "200")));
        }
    }
}