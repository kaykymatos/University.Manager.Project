using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Controllers
{
    [Authorize]
    public class StudentController(IStudentService service, ICourseCategoryService categoryService) : BaseController
    {
        private readonly IStudentService _service = service;
        private readonly ICourseCategoryService _categoryService = categoryService;

        public async Task<ActionResult> Index()
        {
            string token = await HttpContext.GetTokenAsync("access_token");

            return View(await _service.FindAll(token));
        }

        public async Task<ActionResult> Details(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }

        public async Task<ActionResult> Create()
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            var courses = await _categoryService.FindAll(token);
            ViewBag.CourseId = new SelectList(courses, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> createModel = await _service.Create(model, token);
            if (createModel.Any())
            {
                var courses = await _categoryService.FindAll(token);
                ViewBag.CourseId = new SelectList(courses, "Id", "Name");

                return View(ModelStateError(model, createModel));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            var courses = await _categoryService.FindAll(token);
            ViewBag.CourseId = new SelectList(courses, "Id", "Name");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> updateModel = await _service.Update(model, token);
            if (updateModel.Any())
            {
                var courses = await _categoryService.FindAll(token);
                ViewBag.CourseId = new SelectList(courses, "Id", "Name");

                return View(ModelStateError(model, updateModel));
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> Delete(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
