using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;
using University.Manager.Project.Web.MVC.Models.Enums;

namespace University.Manager.Project.Web.MVC.Controllers
{
    [Authorize]
    public class CourseInstallmentController(ICourseInstallmentService service, IStudentService studentService) : BaseController
    {
        private readonly ICourseInstallmentService _service = service;
        private readonly IStudentService _studentService = studentService;

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

            var students = await _studentService.FindAll(token);
            ViewBag.InstallmentStatus = Enum.GetValues(typeof(EInstallmentStatus))
                                       .Cast<EInstallmentStatus>()
                                       .Select(e => new SelectListItem
                                       {
                                           Value = ((int)e).ToString(),
                                           Text = e.ToString()
                                       })
                                       .ToList();

            ViewBag.PaymentMethod = Enum.GetValues(typeof(EInstallmentStatus))
                                     .Cast<EPaymentMethod>()
                                     .Select(e => new SelectListItem
                                     {
                                         Value = ((int)e).ToString(),
                                         Text = e.ToString()
                                     })
                                     .ToList();
            ViewBag.StudentsId = new SelectList(students, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourseInstallmentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> createModel = await _service.Create(model, token);
            if (createModel.Any())
            {
                var students = await _studentService.FindAll(token);
                ViewBag.InstallmentStatus = Enum.GetValues(typeof(EInstallmentStatus))
                                           .Cast<EInstallmentStatus>()
                                           .Select(e => new SelectListItem
                                           {
                                               Value = ((int)e).ToString(),
                                               Text = e.ToString()
                                           })
                                           .ToList();

                ViewBag.PaymentMethod = Enum.GetValues(typeof(EInstallmentStatus))
                                         .Cast<EPaymentMethod>()
                                         .Select(e => new SelectListItem
                                         {
                                             Value = ((int)e).ToString(),
                                             Text = e.ToString()
                                         })
                                         .ToList();
                ViewBag.StudentsId = new SelectList(students, "Id", "Name");

                return View(ModelStateError(model, createModel));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
           
            var students = await _studentService.FindAll(token);
            ViewBag.StudentsId = new SelectList(students, "Id", "Name");
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CourseInstallmentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> updateModel = await _service.Update(model, token);
            if (updateModel.Any())
            {
                var students = await _studentService.FindAll(token);
                ViewBag.InstallmentStatus = Enum.GetValues(typeof(EInstallmentStatus))
                                           .Cast<EInstallmentStatus>()
                                           .Select(e => new SelectListItem
                                           {
                                               Value = ((int)e).ToString(),
                                               Text = e.ToString()
                                           })
                                           .ToList();

                ViewBag.PaymentMethod = Enum.GetValues(typeof(EInstallmentStatus))
                                         .Cast<EPaymentMethod>()
                                         .Select(e => new SelectListItem
                                         {
                                             Value = ((int)e).ToString(),
                                             Text = e.ToString()
                                         })
                                         .ToList();
                ViewBag.StudentsId = new SelectList(students, "Id", "Name");

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
        public async Task<ActionResult> Delete(CourseInstallmentViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            bool deleteModel = await _service.DeleteById(model.Id, token);
            if (deleteModel)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
