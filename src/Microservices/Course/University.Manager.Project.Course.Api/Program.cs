using FluentValidation;
using University.Manager.Project.Course.Api.Endpoints.V1;
using University.Manager.Project.Course.Api.Validation;
using University.Manager.Project.Course.Application.DTOs.RequestDTOs;
using University.Manager.Project.Course.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddTransient<IValidator<CourseEntityRequestDTO>, CourseEntityRequestDTOValidation>();
builder.Services.AddTransient<IValidator<CourseCategoryRequestDTO>, CourseCategoryRequestDTOValidation>();

var app = builder.Build();

app.MapCourseCategoryEndpoints();
app.MapCourseEndpoints();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();