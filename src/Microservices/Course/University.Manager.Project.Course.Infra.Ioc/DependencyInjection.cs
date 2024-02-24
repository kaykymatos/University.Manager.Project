using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Application.Interfaces;
using University.Manager.Project.Course.Application.Mapping;
using University.Manager.Project.Course.Application.Services;
using University.Manager.Project.Course.Application.Validation;
using University.Manager.Project.Course.Domain.Interfaces;
using University.Manager.Project.Course.Infra.Data.Context;
using University.Manager.Project.Course.Infra.Data.Repositories;

namespace University.Manager.Project.Course.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
    {

        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "University.Manager.Project.Course.Api", Version = "v1" });
            x.EnableAnnotations();
        });

        services.AddControllers();

        services.AddDbContext<ApplicationContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly(typeof(ApplicationContext)
           .Assembly.FullName)));

        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<ICourseCategoryService, CourseCategoryService>();
        services.AddScoped<ICourseService, CourseService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        services.AddTransient<IValidator<CourseEntityRequestDTO>, CourseEntityRequestDTOValidation>();
        services.AddTransient<IValidator<CourseCategoryRequestDTO>, CourseCategoryRequestDTOValidation>();

        return services;
    }
}
