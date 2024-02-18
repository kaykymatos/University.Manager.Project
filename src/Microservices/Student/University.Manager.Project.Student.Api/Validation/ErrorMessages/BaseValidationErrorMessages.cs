namespace University.Manager.Project.Student.Api.Validation.ErrorMessages
{
    public class BaseValidationErrorMessages
    {
        public static string FieldNull = "The field {PropertyName} can't be null!";
        public static string FieldEmail = "The field {PropertyName} must be a valid email!";
        public static string FieldMinLenght = "The field {PropertyName} is too short, minimum length {MinLength}!";
        public static string FieldNumberMustBeGreaterThan = "The field {PropertyName} can't be less than or equals to {ComparisonValue}!";
        public static string FieldNumberMustBeLessThan = "The field {PropertyName} can't be greater than {ComparisonValue}!";
        public static string FieldMaxLenght = "The field {PropertyName} is too long, maximum length {MaxLength}!";
        public static string FieldWithSpecialCharacters = "The field {PropertyName} can't contains special characters!";

    }
}
