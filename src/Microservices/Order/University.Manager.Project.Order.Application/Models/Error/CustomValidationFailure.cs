namespace University.Manager.Project.Order.Application.Models.Error
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
            return
            [
                new CustomValidationFailure(PropertyName, ErrorMessage),
            ];
        }
    }
}
