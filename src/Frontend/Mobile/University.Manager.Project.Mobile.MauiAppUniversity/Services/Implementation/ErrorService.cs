using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class ErrorService
    {
        private IEnumerable<ApiErrorViewModel> errorViewModels = new List<ApiErrorViewModel>();

        public string GetFieldErrors(string fieldName, IEnumerable<ApiErrorViewModel> errorViewModels)
        {
            return errorViewModels
                .Where(error => error.PropertyName == fieldName)
                .Select(error => error.ErrorMessage).FirstOrDefault();
        }


        public void ClearErrors()
        {
            errorViewModels = new List<ApiErrorViewModel>();
        }
    }
}
