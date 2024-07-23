using Microsoft.AspNetCore.Authentication;
using MudBlazor.Services;
using System.Globalization;
using University.Manager.Project.Web.Blazor;
using University.Manager.Project.Web.Blazor.Extensions;
using University.Manager.Project.Web.Blazor.Pages;
using University.Manager.Project.Web.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuickGridEntityFrameworkAdapter(); ;

// Add services to the container.
builder.Services.AddRazorComponents(options =>
    options.DetailedErrors = builder.Environment.IsDevelopment())
    .AddInteractiveServerComponents();

//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
//CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenService>();


builder.ConfigHttpServices();
builder.Services.AddMudServices();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";

})
    .AddCookie("Cookies", x => x.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "universityBlazor";
        options.ClientSecret = Environment.GetEnvironmentVariable("SecretIdentityBlazor");
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("universityBlazor");
        options.SaveTokens = true;
    });
builder.Services.AddSingleton<ErrorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAntiforgery();
//app.Use(async (context, next) =>
//{
//    // Verificar se o usuário está autenticado e se a rota requer uma role específica
//    if (context.User.Identity.IsAuthenticated)
//    {
//        Endpoint endpoint = context.GetEndpoint();
//        if (endpoint != null)
//        {
//            AuthorizeAttribute authorizeAttribute = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();
//            if (authorizeAttribute != null && authorizeAttribute.Roles != null)
//            {
//                string[] roles = authorizeAttribute.Roles.Split(',');
//                bool userHasRequiredRole = roles.Any(role => context.User.IsInRole(role));

//                if (!userHasRequiredRole)
//                {
//                    HttpRequest requestVariable = context.Request;
//                    string returnUrl = $"{requestVariable.Scheme}://{requestVariable.Host.Host}:{requestVariable.Host.Port}";
//                    string accessDeniedUrl = $"{builder.Configuration["ServiceUrls:IdentityServer"]}/Account/AccessDenied?returnUrl={Uri.EscapeDataString(returnUrl)}";
//                    context.Response.Redirect(accessDeniedUrl);
//                    return;
//                }
//            }
//        }
//    }

//    await next();
//});

app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
