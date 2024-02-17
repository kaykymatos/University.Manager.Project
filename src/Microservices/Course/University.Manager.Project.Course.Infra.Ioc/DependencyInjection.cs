using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Application.Mapping;
using University.Manager.Project.Course.Application.Services;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;
using University.Manager.Project.Course.Infra.Data.Repositories;

namespace University.Manager.Project.Course.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
    {

        services.AddSwaggerGen();

        services.AddDbContext<ApplicationContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly(typeof(ApplicationContext)
           .Assembly.FullName)));


        services.ConfigureApplicationCookie(x =>
        x.AccessDeniedPath = "/Account/Login");

        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<ICourseCategoryService, CourseCategoryService>();
        services.AddScoped<ICourseService, CourseService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
