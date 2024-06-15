using FluentValidation.Results;

namespace University.Manager.Project.Student.Application.Models.Error
{
    public static class ValidationFailureExtension
    {
        public static IList<CustomValidationFailure> ToCustomValidationFailure(this IList<ValidationFailure> failures)
        {
            return failures.Select(x => new CustomValidationFailure(x.PropertyName, x.ErrorMessage)).ToList();
        }
    }
}
