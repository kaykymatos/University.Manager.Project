using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.Manager.Project.Web.MVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
