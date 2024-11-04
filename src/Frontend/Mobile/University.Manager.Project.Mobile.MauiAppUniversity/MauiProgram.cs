using IdentityModel;
using IdentityModel.OidcClient;
using LiteDB;
using Microsoft.Extensions.Logging;
using System.Net.Security;
using University.Manager.Project.Mobile.MauiAppUniversity.Repositories.Implementation;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation;
using University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Views;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.CourseCategory;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Courses;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Installments;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Orders;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions.Student;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.CourseCategory;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Courses;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Installments;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Orders;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Student;
using University.Manager.Project.Web.Blazor.Repositories.Implementation;


namespace University.Manager.Project.Mobile.MauiAppUniversity
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("Brands-Regular-400.otf", "FAB");
                    fonts.AddFont("Free-Regular-400.otf", "FAR");
                    fonts.AddFont("Free-Solid-900.otf", "FAS");
                })
                .RegisterViews()
                .RegisterRepositoriesAndServices();



            builder.Services.AddSingleton<MauiAuthenticationBrowser>();

            builder.Services.AddSingleton(new OidcClient(
                new OidcClientOptions
            {
                Authority = "https://10.0.2.2:4435",
                ClientId = "universityMaui",
                Scope = "universityMaui",
                ClientSecret = "MySuperSecret",
                    RedirectUri = "university.manager.project.mobile.mauiappuniversity://callback",
                    Browser = new MauiAuthenticationBrowser(),
                HttpClientFactory = (options) =>
                                    {
                                        var handler = new HttpsClientHandlerService();
                                        
                                        return new HttpClient(handler.GetPlatformMessageHandler());
                                    }
            }));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();

            //Course category pages
            mauiAppBuilder.Services.AddTransient<CourseCategoriesList>();
            mauiAppBuilder.Services.AddTransient<CreateCourseCategory>();
            mauiAppBuilder.Services.AddTransient<DeleteCourseCategory>();
            mauiAppBuilder.Services.AddTransient<DetailsCourseCategory>();
            mauiAppBuilder.Services.AddTransient<EditCourseCategory>();

            //Course page
            mauiAppBuilder.Services.AddTransient<CoursesList>();
            mauiAppBuilder.Services.AddTransient<CreateCourse>();
            mauiAppBuilder.Services.AddTransient<DeleteCourse>();
            mauiAppBuilder.Services.AddTransient<DetailsCourse>();
            mauiAppBuilder.Services.AddTransient<EditCourse>();

            //Installment pages
            mauiAppBuilder.Services.AddTransient<InstallmentsList>();
            mauiAppBuilder.Services.AddTransient<CreateInstallment>();
            mauiAppBuilder.Services.AddTransient<DeleteInstallment>();
            mauiAppBuilder.Services.AddTransient<DetaislInstallment>();
            mauiAppBuilder.Services.AddTransient<EditInstallment>();

            //Order Pages
            mauiAppBuilder.Services.AddTransient<OrdersList>();
            mauiAppBuilder.Services.AddTransient<CreateOrder>();
            mauiAppBuilder.Services.AddTransient<DeleteOrder>();
            mauiAppBuilder.Services.AddTransient<DetailsOrder>();
            mauiAppBuilder.Services.AddTransient<EditOrder>();

            //Student Pages
            mauiAppBuilder.Services.AddTransient<StudentsList>();
            mauiAppBuilder.Services.AddTransient<CreateStudent>();
            mauiAppBuilder.Services.AddTransient<DeleteStudent>();
            mauiAppBuilder.Services.AddTransient<DetailsStudent>();
            mauiAppBuilder.Services.AddTransient<EditStudent>();


            mauiAppBuilder.Services.AddTransient<HomePage>();
            mauiAppBuilder.Services.AddTransient<InfoPage>();
            mauiAppBuilder.Services.AddTransient<ActionsListPage>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterRepositoriesAndServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton(options => { return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared"); });

            mauiAppBuilder.Services.AddTransient<ICourseRepository, CourseRepository>();
            mauiAppBuilder.Services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
            mauiAppBuilder.Services.AddTransient<ICourseInstallmentRepository, CourseInstallmentRepository>();
            mauiAppBuilder.Services.AddTransient<IOrderRepository, OrderRepository>();
            mauiAppBuilder.Services.AddTransient<IStudentRepository, StudentRepository>();

            mauiAppBuilder.Services.AddTransient<ICourseCategoryService, CourseCategoryService>();
            mauiAppBuilder.Services.AddTransient<ICourseService, CourseService>();
            mauiAppBuilder.Services.AddTransient<ICourseInstallmentService, CourseInstallmentService>();
            mauiAppBuilder.Services.AddTransient<IOrderService, OrderService>();
            mauiAppBuilder.Services.AddTransient<IStudentService, StudentService>();

            var url = DeviceInfo.Platform == DevicePlatform.Android ? "https://127.0.0.1:4480" : "https://localhost:4480";

            mauiAppBuilder.Services.AddHttpClient<ICourseCategoryService, CourseCategoryService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });
            mauiAppBuilder.Services.AddHttpClient<ICourseInstallmentService, CourseInstallmentService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });
            mauiAppBuilder.Services.AddHttpClient<ICourseService, CourseService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });
            mauiAppBuilder.Services.AddHttpClient<IStudentService, StudentService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });
            mauiAppBuilder.Services.AddHttpClient<IStudentService, StudentService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });
            mauiAppBuilder.Services.AddHttpClient<IOrderService, OrderService>(x =>
            {
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.BaseAddress = new Uri(url);
            });

            return mauiAppBuilder;
        }
    }
}
