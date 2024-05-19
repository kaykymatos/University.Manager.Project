using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Student.Application.Test.Builder;
using University.Manager.Project.Student.Application.Validation;
using University.Manager.Project.Student.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Student.Application.Test
{
    public class StudentEntityRequestDTOTests
    {
        private readonly StudentEntityRequestDTOBuilder _builder;
        private readonly StudentEntityRequestDTOValidation _validator;

        public StudentEntityRequestDTOTests()
        {
            ServiceProvider provider = new ServiceCollection()
                .AddTransient<StudentEntityRequestDTOValidation>()
                .BuildServiceProvider();

            _builder = new StudentEntityRequestDTOBuilder();
            _validator = provider.GetService<StudentEntityRequestDTOValidation>();
        }
        [Fact]
        public async Task CreateStudentWithValidParameters()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        [Fact]
        public async Task CreateStudentEntity_WithStudentIdLess_ResultObjectInvalidStudentIdMustBeGreaterThan()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.With(x => x.StudentId = 0).Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Student Id").Replace("{ComparisonValue}", "0")));
        }
        [Fact]
        public async Task CreateStudentEntity_WithCourseIdLess_ResultObjectInvalidCourseIMustBeGreaterThan()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.With(x => x.CourseId = 0).Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Course Id").Replace("{ComparisonValue}", "0")));
        }
        [Fact]
        public async Task CreateStudentEntity_WithRegisterCodeLess_ResultObjectInvalidRegisterCodeMustBeGreaterThan()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.With(x => x.RegisterCode = "12").Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMinLenght.Replace("{PropertyName}", "Register Code").Replace("{MinLength}", "3")));
        }
        [Fact]
        public async Task CreateStudentEntity_WithRegisterCodeGreater_ResultObjectInvalidRegisterCodeMustBeLessThan()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.With(x => x.RegisterCode = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111").Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldMaxLenght.Replace("{PropertyName}", "Register Code").Replace("{MaxLength}", "200")));
        }
        [Fact]
        public async Task CreateStudentEntity_WithRegisterCodeEmpty_ResultObjectInvalidRegisterCodeCanotBeNull()
        {
            DTOs.RequestDTOs.StudentEntityRequestDTO instance = _builder.With(x => x.RegisterCode = string.Empty).Build();
            FluentValidation.Results.ValidationResult validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNull.Replace("{PropertyName}", "Register Code")));
        }
    }
}