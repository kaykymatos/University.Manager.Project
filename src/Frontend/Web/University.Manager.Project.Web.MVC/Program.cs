using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using University.Manager.Project.Web.MVC.Interfaces;
using University.Manager.Project.Web.MVC.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
        options.ClientId = "university";
        options.ClientSecret = Environment.GetEnvironmentVariable("SecretIdentity");
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("university");
        options.SaveTokens = true;
    });
builder.Services.AddHttpClient<ICourseCategoryService, CourseCategoryService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
});
builder.Services.AddHttpClient<ICourseInstallmentService, CourseInstallmentService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
});
builder.Services.AddHttpClient<ICourseService, CourseService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
});
builder.Services.AddHttpClient<IOrderService, OrderService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
});
builder.Services.AddHttpClient<IStudentService, StudentService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ApiGateway"]);
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.Use(async (context, next) =>
{
    // Verificar se o usuário está autenticado e se a rota requer uma role específica
    if (context.User.Identity.IsAuthenticated)
    {
        Endpoint endpoint = context.GetEndpoint();
        if (endpoint != null)
        {
            AuthorizeAttribute authorizeAttribute = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();
            if (authorizeAttribute != null && authorizeAttribute.Roles != null)
            {
                string[] roles = authorizeAttribute.Roles.Split(',');
                bool userHasRequiredRole = roles.Any(role => context.User.IsInRole(role));

                if (!userHasRequiredRole)
                {
                    HttpRequest requestVariable = context.Request;
                    string returnUrl = $"{requestVariable.Scheme}://{requestVariable.Host.Host}:{requestVariable.Host.Port}";
                    string accessDeniedUrl = $"{builder.Configuration["ServiceUrls:IdentityServer"]}/Account/AccessDenied?returnUrl={Uri.EscapeDataString(returnUrl)}";
                    context.Response.Redirect(accessDeniedUrl);
                    return;
                }
            }
        }
    }

    await next();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
