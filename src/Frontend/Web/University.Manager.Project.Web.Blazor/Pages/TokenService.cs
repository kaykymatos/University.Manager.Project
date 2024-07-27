using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace University.Manager.Project.Web.Blazor.Pages
{
    public class TokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticationService _authenticationService;

        public TokenService(IHttpContextAccessor httpContextAccessor, IAuthenticationService authenticationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticationService = authenticationService;
        }
        public async Task<string> GetTokenAsync()
        {
            var authenticateResult = await _httpContextAccessor.HttpContext.AuthenticateAsync("oidc");
            
            if (authenticateResult.Properties != null)
                return authenticateResult.Properties.GetTokenValue("access_token");
            return string.Empty;
        }
    }
}
