namespace University.Manager.Project.Student.Application.Models.Error
{
    public class CustomValidationFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
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
