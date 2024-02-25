using University.Manager.Project.Student.Api.Endpoints.V1;
using University.Manager.Project.Student.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);

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
