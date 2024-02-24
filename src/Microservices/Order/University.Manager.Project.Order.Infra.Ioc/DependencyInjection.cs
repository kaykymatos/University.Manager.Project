using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using University.Manager.Project.Order.Application.DTOs.RequestDTOs;
using University.Manager.Project.Order.Application.Interfaces;
using University.Manager.Project.Order.Application.Mapping;
using University.Manager.Project.Order.Application.Services;
using University.Manager.Project.Order.Application.Validation;
using University.Manager.Project.Order.Domain.Interfaces;
using University.Manager.Project.Order.Infra.Data.Context;
using University.Manager.Project.Order.Infra.Data.Repositories;

namespace University.Manager.Project.Order.Infra.Ioc
{
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

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddTransient<IValidator<OrderEntityRequestDTO>, OrderEntityRequestDTOValidation>();

            return services;
        }
    }
}
