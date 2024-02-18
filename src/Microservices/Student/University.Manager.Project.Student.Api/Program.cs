using FluentValidation;
using University.Manager.Project.Student.Api.Endpoints.V1;
using University.Manager.Project.Student.Api.Validation;
using University.Manager.Project.Student.Application.DTOs.RequestDTOs;
using University.Manager.Project.Student.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<IValidator<StudentEntityRequestDTO>, StudentEntityRequestDTOValidation>();

var app = builder.Build();

app.MapStudentEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
