using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using University.Manager.Project.IdentityServer.Configuration;
using University.Manager.Project.IdentityServer.Data;

namespace University.Manager.Project.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role
            )
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Student)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
               IdentityConfiguration.Employer)).GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "kayky-admin",
                Email = "kayky-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            IdentityResult adminClaims = _user.AddClaimsAsync(admin,
            [
                new (JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new (JwtClaimTypes.GivenName, admin.FirstName),
                new (JwtClaimTypes.FamilyName, admin.LastName),
                new (JwtClaimTypes.Role, IdentityConfiguration.Admin)
            ]).Result;

            ApplicationUser client = new()
            {
                UserName = "kayky-client",
                Email = "kayky-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                IdentityConfiguration.Student).GetAwaiter().GetResult();
            IdentityResult clientClaims = _user.AddClaimsAsync(client,
            [
                new(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new(JwtClaimTypes.GivenName, client.FirstName),
                new(JwtClaimTypes.FamilyName, client.LastName),
                new (JwtClaimTypes.Role, IdentityConfiguration.Student)
            ]).Result;

            ApplicationUser employer = new()
            {
                UserName = "kayky-employer",
                Email = "kayky-employer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Employer"
            };

            _user.CreateAsync(employer, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(employer,
                IdentityConfiguration.Student).GetAwaiter().GetResult();
            IdentityResult employerClaims = _user.AddClaimsAsync(employer,
            [
                new Claim(JwtClaimTypes.Name, $"{employer.FirstName} {employer.LastName}"),
                new Claim(JwtClaimTypes.GivenName, employer.FirstName),
                new Claim(JwtClaimTypes.FamilyName, employer.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Student)
            ]).Result;
        }

    }
}
