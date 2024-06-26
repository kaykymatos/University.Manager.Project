using University.Manager.Project.Course.Api.Endpoints.V1;
using University.Manager.Project.Course.Infra.Ioc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);


WebApplication app = builder.Build();

app.MapCourseCategoryEndpoints();
app.MapCourseEndpoints();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();