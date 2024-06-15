using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Controllers
{
    public class BaseController : Controller
    {
        internal object ModelStateError(object model, IEnumerable<ApiErrorViewModel> errors)
        {
            foreach (ApiErrorViewModel item in errors)
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            return model;
        }
    }
}
