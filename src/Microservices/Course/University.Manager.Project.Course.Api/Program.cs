using University.Manager.Project.Course.Api.Endpoints.V1;
using University.Manager.Project.Course.Infra.Ioc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);


WebApplication app = builder.Build();

new CourseCategoryEndpoints().MapEndpoints(app);
new CourseEndpoints().MapEndpoints(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();