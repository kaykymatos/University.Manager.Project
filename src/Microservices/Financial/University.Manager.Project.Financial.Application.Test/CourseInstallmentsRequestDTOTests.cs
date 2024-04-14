﻿using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Financial.Application.Test.Builder;
using University.Manager.Project.Financial.Application.Validation;
using University.Manager.Project.Financial.Application.Validation.ErrorMessages;

namespace University.Manager.Project.Financial.Application.Test
{
    public class CourseInstallmentsRequestDTOTests
    {
        private readonly CourseInstallmentsRequestDTOBuilder _builder;
        private readonly CourseInstallmentsRequestDTOValidation _validator;

        public CourseInstallmentsRequestDTOTests()
        {
            var provider = new ServiceCollection()
                .AddTransient<CourseInstallmentsRequestDTOValidation>()
                .BuildServiceProvider();

            _builder = new CourseInstallmentsRequestDTOBuilder();
            _validator = provider.GetService<CourseInstallmentsRequestDTOValidation>();
        }
        [Fact]
        public async Task CreateStudentWithValidParameters()
        {
            var instance = _builder.Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }




        [Fact]
        public async Task CreateCourseInstallment_WithInvalidStudentId_ResultStudentIdMustBeGreterThan()
        {
            var instance = _builder.With(x => x.StudentId = 0).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Student Id").Replace("{ComparisonValue}", "0")));

        }
        [Fact]
        public async Task CreateCourseInstallment_WithInvalidInstallmentPrice_ResultStudentIdMustBeGreaterThan()
        {
            var instance = _builder.With(x => x.InstallmentPrice = 0).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeGreaterThan.Replace("{PropertyName}", "Installment Price").Replace("{ComparisonValue}", "0")));

        }
        [Fact]
        public async Task CreateCourseInstallment_WithInvalidInstallmentPrice_ResultStudentIdMustBeLessThan()
        {
            var instance = _builder.With(x => x.InstallmentPrice = 100000000).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(BaseValidationErrorMessages.FieldNumberMustBeLessThan.Replace("{PropertyName}", "Installment Price").Replace("{ComparisonValue}", "999999")));

        }


        [Fact]
        public async Task CreateCourseInstallment_WithInvalidDueDate_ResultDueDateMustBeLessThanToday()
        {
            var instance = _builder.With(x => x.DueDate = DateTime.Today.AddDays(-2)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains("The filed Due Date must bee greater today!"));

        }
    }
}