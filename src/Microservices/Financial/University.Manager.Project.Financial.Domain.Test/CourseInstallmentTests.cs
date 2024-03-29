using FluentAssertions;
using University.Manager.Project.Financial.Domain.Entities;
using University.Manager.Project.Financial.Domain.Entities.Enums;
using University.Manager.Project.Financial.Domain.Validation;

namespace University.Manager.Project.Financial.Domain.Test
{
    public class CourseInstallmentTests
    {
        [Fact]
        public void CreateCourseInstallment_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new CourseInstallments(1, 1, 999, null, DateTime.Now.AddMonths(2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCourseInstallment_WithInvalidStudentId_ResultStudentIdMustBeGreterThan()
        {
            Action action = () => new CourseInstallments(1, 0, 999, null, DateTime.Now.AddMonths(2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Student Id, Student Id is required!");
        }
        [Fact]
        public void CreateCourseInstallment_WithInvalidInstallmentPrice_ResultStudentIdMustBeGreaterThan()
        {
            Action action = () => new CourseInstallments(1, 1, 0, null, DateTime.Now.AddMonths(2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Installment price, Installment price is required!");
        }
        [Fact]
        public void CreateCourseInstallment_WithInvalidInstallmentPrice_ResultStudentIdMustBeLessThan()
        {
            Action action = () => new CourseInstallments(1, 1, 1000000, null, DateTime.Now.AddMonths(2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Installment price, Installment price is too long, maximum $999998.00!");
        }
        [Fact]
        public void CreateCourseInstallment_WithInvalidPaymentDate_ResultPaymentDateBeGreterThan()
        {
            Action action = () => new CourseInstallments(1, 1, 1, DateTime.Now.AddDays(-2), DateTime.Now.AddMonths(2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Payment Date, Payment Date cannot be in the past!");
        }
        [Fact]
        public void CreateCourseInstallment_WithInvalidDueDate_ResultDueDateMustBeLessThanToday()
        {
            Action action = () => new CourseInstallments(1, 1, 1, DateTime.Now.AddDays(2), DateTime.Now.AddMonths(-2), EInstallmentStatus.Pending, EPaymentMethod.Other);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Due Date, Due Date cannot be in the past!");
        }
    }
}