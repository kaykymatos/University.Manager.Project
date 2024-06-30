using University.Manager.Project.Web.Blazor.Services;

namespace University.Manager.Project.Web.Blazor.Extensions
{
    public static class HttpServicesConfig
    {
        public static void ConfigHttpServices(this WebApplicationBuilder builder)
        {
           builder.Services.AddHttpClient<ICourseService, CourseService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
            });
           builder.Services.AddHttpClient<ICourseCategoryService, CourseCategoryService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
            });
        }
    }
}
