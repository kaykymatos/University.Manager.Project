using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MudBlazor.Services;
using University.Manager.Project.Web.Blazor;
using University.Manager.Project.Web.Blazor.Extensions;
using University.Manager.Project.Web.Blazor.Pages;
using University.Manager.Project.Web.Blazor.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuickGridEntityFrameworkAdapter(); ;

builder.Services.AddRazorComponents(options =>
    options.DetailedErrors = builder.Environment.IsDevelopment())
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenService>();


builder.ConfigHttpServices();
builder.Services.AddMudServices();

builder.Services.AddScoped<SignOutSessionStateManager>();

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

        options.SignedOutCallbackPath = new PathString("/signout-callback-oidc");
        options.SignedOutRedirectUri = "/";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAntiforgery();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapPost("/account/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await context.SignOutAsync("oidc");
});
app.Run();
