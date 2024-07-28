using University.Manager.Project.Student.Api.Endpoints.V1;
using University.Manager.Project.Student.Infra.Ioc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

new StudentEndpoints().MapEndpoints(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
