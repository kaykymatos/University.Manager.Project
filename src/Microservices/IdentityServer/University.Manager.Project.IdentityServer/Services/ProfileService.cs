using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using University.Manager.Project.IdentityServer.Data;

namespace University.Manager.Project.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipal;

        public ProfileService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipal)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaimsPrincipal = userClaimsPrincipal;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string id = context.Subject.GetSubjectId();
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            ClaimsPrincipal userClaims = await _userClaimsPrincipal.CreateAsync(user);
            List<Claim> claims = userClaims.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));

            if (_userManager.SupportsUserRole)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (string role in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, role));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        IdentityRole identityRole = await _roleManager.FindByIdAsync(role);
                        if (identityRole != null)
                            claims.AddRange(await _roleManager.GetClaimsAsync(identityRole));
                    }
                }
            }
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string id = context.Subject.GetSubjectId();
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            context.IsActive = user != null;
        }
    }
}
