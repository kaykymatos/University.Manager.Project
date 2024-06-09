using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Controllers
{
    [Authorize]
    public class StudentController(IStudentService service, ICourseService courseService) : BaseController
    {
        private readonly IStudentService _service = service;
        private readonly ICourseService _courseService = courseService;

        public async Task<ActionResult> Index()
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<CourseViewModel> courses = await _courseService.FindAll(token);
            ViewBag.Courses = courses;
            return View(await _service.FindAll(token));
        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Details(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Create()
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<CourseViewModel> courses = await _courseService.FindAll(token);
            ViewBag.CourseId = courses;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Create(StudentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> createModel = await _service.Create(model, token);
            if (createModel.Any())
            {
                IEnumerable<CourseViewModel> courses = await _courseService.FindAll(token);
                ViewBag.CourseId = courses;

                return View(ModelStateError(model, createModel));
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Edit(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<CourseViewModel> courses = await _courseService.FindAll(token);
            ViewBag.CourseId = courses;
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Edit(StudentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> updateModel = await _service.Update(model, token);
            if (updateModel.Any())
            {
                IEnumerable<CourseViewModel> courses = await _courseService.FindAll(token);
                ViewBag.CourseId = courses;

                return View(ModelStateError(model, updateModel));
            }
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Delete(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Delete(StudentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            bool deleteModel = await _service.DeleteById(model.Id, token);
            if (deleteModel)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
