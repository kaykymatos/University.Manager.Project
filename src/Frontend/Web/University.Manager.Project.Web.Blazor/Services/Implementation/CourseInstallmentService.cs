﻿using University.Manager.Project.Web.Blazor.Models;
using University.Manager.Project.Web.Blazor.Services.Interfaces;

namespace University.Manager.Project.Web.Blazor.Services.Implementation
{
    public class CourseInstallmentService(HttpClient client, string basePath = "api/v1/financial") : BaseService<CourseInstallmentViewModel>(client, basePath), ICourseInstallmentService
    {
    }
}