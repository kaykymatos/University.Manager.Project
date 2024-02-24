using University.Manager.Project.Order.Api.Endpoints.V1;
using University.Manager.Project.Order.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.MapOrderEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
