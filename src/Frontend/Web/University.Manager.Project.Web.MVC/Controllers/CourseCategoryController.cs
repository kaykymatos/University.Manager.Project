using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Controllers
{
    [Authorize]
    public class CourseCategoryController(ICourseCategoryService service) : BaseController
    {
        private readonly ICourseCategoryService _service = service;

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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(CourseCategoryViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> createModel = await _service.Create(model, token);
            if (createModel.Any())
                return View(ModelStateError(model, createModel));
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(CourseCategoryViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> updateModel = await _service.Update(model, token);
            if (updateModel.Any())
                return View(ModelStateError(model, updateModel));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(CourseCategoryViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            bool deleteModel = await _service.DeleteById(model.Id, token);
            if (deleteModel)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
