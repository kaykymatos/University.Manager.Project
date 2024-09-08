using LiteDB;
using Microsoft.Extensions.Logging;
using University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;


namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViews()
                .RegisterRepositoriesAndServices();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<CourseCategory>();
            mauiAppBuilder.Services.AddTransient<Courses>();
            mauiAppBuilder.Services.AddTransient<Installments>();
            mauiAppBuilder.Services.AddTransient<Orders>();
            mauiAppBuilder.Services.AddTransient<Student>();
            mauiAppBuilder.Services.AddTransient<HomePage>();
            mauiAppBuilder.Services.AddTransient<InfoPage>();
            mauiAppBuilder.Services.AddTransient<ActionsListPage>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterRepositoriesAndServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton(options => { return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared"); });

            mauiAppBuilder.Services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
            mauiAppBuilder.Services.AddTransient<ICourseRepository, CourseRepository>();
            mauiAppBuilder.Services.AddTransient<ICourseInstallmentRepository, CourseInstallmentRepository>();
            mauiAppBuilder.Services.AddTransient<IOrderRepository, OrderRepository>();
            mauiAppBuilder.Services.AddTransient<IStudentRepository, StudentRepository>();

            mauiAppBuilder.Services.AddTransient<ICourseCategoryService, CourseCategoryService>();
            mauiAppBuilder.Services.AddTransient<ICourseService, CourseService>();
            mauiAppBuilder.Services.AddTransient<ICourseInstallmentService, CourseInstallmentService>();
            mauiAppBuilder.Services.AddTransient<IOrderService, OrderService>();
            mauiAppBuilder.Services.AddTransient<IStudentService, StudentService>();

            return mauiAppBuilder;
        }
    }
}
