using University.Manager.Project.Order.Api.Endpoints.V1;
using University.Manager.Project.Order.Infra.Ioc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();
new OrderEndpoints().MapEndpoints(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
