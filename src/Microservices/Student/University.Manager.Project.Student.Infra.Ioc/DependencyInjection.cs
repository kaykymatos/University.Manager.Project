﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using University.Manager.Project.Student.Application.Interfaces;
using University.Manager.Project.Student.Application.Mapping;
using University.Manager.Project.Student.Application.Services;
using University.Manager.Project.Student.Domain.Interfaces;
using University.Manager.Project.Student.Infra.Data.Context;
using University.Manager.Project.Student.Infra.Data.Repositories;

namespace University.Manager.Project.Student.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                 IConfiguration configuration)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "University.Manager.Project.Student.Api", Version = "v1" });
                x.EnableAnnotations();
            });

            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly(typeof(ApplicationContext)
               .Assembly.FullName)));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISecurityService, SecurityService>();


            return services;
        }
    }
}
