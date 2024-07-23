using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Models;
using University.Manager.Project.Web.MVC.Models.Enums;

namespace University.Manager.Project.Web.MVC.Controllers
{
    [Authorize]
    public class OrderController(IOrderService service, IStudentService studentService) : BaseController
    {
        private readonly IOrderService _service = service;
        private readonly IStudentService _studentService = studentService;

        public async Task<ActionResult> Index()
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.Students = _studentService.FindAll(token).Result;
            return View(await _service.FindAll(token));
        }

        public async Task<ActionResult> Details(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            ViewBag.Students = _studentService.FindAll(token).Result;
            return View(await _service.FindById(id, token));
        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Create()
        {
            string token = await HttpContext.GetTokenAsync("access_token");

            IEnumerable<StudentViewModel> students = await _studentService.FindAll(token);
            ViewBag.Usuario = new SelectList(students, "Id", "Name");

            ViewBag.OrderType = Enum.GetValues(typeof(ETypeOrder))
                                          .Cast<ETypeOrder>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ToString()
                                          })
                                          .ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Create(OrderViewModel model, IFormFile Attachment)
        {
            string base64String = string.Empty;
            if (Attachment != null)
            {
                if (Attachment.Length > 0)
                {
                    using (MemoryStream memoryStream = new())
                    {
                        Attachment.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();
                        base64String = Convert.ToBase64String(bytes);

                    }

                    model.Attachment = base64String;
                }

            }

            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> createModel = await _service.Create(model, token);
            if (createModel.Any())
            {
                IEnumerable<StudentViewModel> students = await _studentService.FindAll(token);
                ViewBag.Usuario = new SelectList(students, "Id", "Name");
                ViewBag.OrderType = Enum.GetValues(typeof(ETypeOrder))
                                          .Cast<ETypeOrder>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ToString()
                                          })
                                          .ToList();
                return View(ModelStateError(model, createModel));
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Edit(int id)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<StudentViewModel> students = await _studentService.FindAll(token);
            ViewBag.Usuario = new SelectList(students, "Id", "Name");
            ViewBag.OrderType = Enum.GetValues(typeof(ETypeOrder))
                                          .Cast<ETypeOrder>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ToString()
                                          })
                                          .ToList();
            return View(await _service.FindById(id, token));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<ActionResult> Edit(OrderViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<ApiErrorViewModel> updateModel = await _service.Update(model, token);
            if (updateModel.Any())
            {
                IEnumerable<StudentViewModel> students = await _studentService.FindAll(token);
                ViewBag.Usuario = new SelectList(students, "Id", "Name");
                ViewBag.OrderType = Enum.GetValues(typeof(ETypeOrder))
                                          .Cast<ETypeOrder>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ToString()
                                          })
                                          .ToList();
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
        public async Task<ActionResult> Delete(OrderViewModel model)
        {
            string token = await HttpContext.GetTokenAsync("access_token");
            bool deleteModel = await _service.DeleteById(model.Id, token);
            if (deleteModel)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}
