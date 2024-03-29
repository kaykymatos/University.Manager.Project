using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using University.Manager.Project.Financial.Application.DTOs.RequestDTOs;
using University.Manager.Project.Financial.Application.Interfaces;
using University.Manager.Project.Financial.Application.Mapping;
using University.Manager.Project.Financial.Application.Services;
using University.Manager.Project.Financial.Application.Validation;
using University.Manager.Project.Financial.Domain.Interfaces;
using University.Manager.Project.Financial.Infra.Data.Context;
using University.Manager.Project.Financial.Infra.Data.Repositories;

namespace University.Manager.Project.Financial.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                 IConfiguration configuration)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "University.Manager.Project.Financial.Api", Version = "v1" });
                x.EnableAnnotations();
            });

            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly(typeof(ApplicationContext)
               .Assembly.FullName)));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddScoped<ICourseInstallmentsRepository, CourseInstallmentsRepository>();
            services.AddScoped<ICourseInstallmentsService, CourseInstallmentsService>();
            services.AddTransient<IValidator<CourseInstallmentsRequestDTO>, CourseInstallmentsRequestDTOValidation>();

            return services;
        }
    }
}
