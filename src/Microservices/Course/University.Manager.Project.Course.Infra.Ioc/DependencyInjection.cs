using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        services.AddControllers();


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = "https://localhost:4435/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "university");

            });
        });

        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "NomeDaApiSwagger", Version = "v1" });
            x.EnableAnnotations();
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"Enter 'Bearer' [space] and your token!",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header
                        },
                        new List<string> ()
                    }
                });
        });


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
