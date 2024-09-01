using Microsoft.Extensions.Logging;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Actions;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Home;
using University.Manager.Project.Mobile.MauiAppUniversity.Views.Info;

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
                });

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
            mauiAppBuilder.Services.AddTransient<Home>();
            mauiAppBuilder.Services.AddTransient<InfoPage>();

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterRepositoriesAndServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<CourseCategory>();
            mauiAppBuilder.Services.AddTransient<Courses>();
            mauiAppBuilder.Services.AddTransient<Installments>();
            mauiAppBuilder.Services.AddTransient<Orders>();
            mauiAppBuilder.Services.AddTransient<Student>();
            mauiAppBuilder.Services.AddTransient<Home>();
            mauiAppBuilder.Services.AddTransient<InfoPage>();

            return mauiAppBuilder;
        }
    }
}
