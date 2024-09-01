﻿using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class CourseCategoryService(HttpClient client, string basePath = "api/v1/courseCategory") : BaseService<CourseCategoryViewModel>(client, basePath), ICourseCategoryService
    {
    }
}
