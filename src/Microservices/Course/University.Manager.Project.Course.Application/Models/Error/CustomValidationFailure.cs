namespace University.Manager.Project.Course.Application.Models.Error
{
    public class CustomValidationFailure
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public CustomValidationFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        public IList<CustomValidationFailure> ToList()
        {
            return new List<CustomValidationFailure>()
            {
                new CustomValidationFailure(PropertyName, ErrorMessage),
            };
        }
    }
}
