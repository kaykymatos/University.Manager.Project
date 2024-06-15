using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using University.Manager.Project.IdentityServer.Data;
using University.Manager.Project.IdentityServer.Models;

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
            if (_role.FindByNameAsync(Config.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                Config.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                Config.Student)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
               Config.Employer)).GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "kayky-admin@gmail.com",
                Email = "kayky-admin@gmail.com",
                NormalizedUserName = "KAYKY-ADMIN@GMAIL.COM",
                NormalizedEmail = "KAYKY-ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin,
                Config.Admin).GetAwaiter().GetResult();
            IdentityResult adminClaims = _user.AddClaimsAsync(admin,
            [
                new (JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new (JwtClaimTypes.GivenName, admin.FirstName),
                new (JwtClaimTypes.FamilyName, admin.LastName),
                new (JwtClaimTypes.Role, Config.Admin)
            ]).Result;

            ApplicationUser client = new()
            {
                UserName = "kayky-client@gmail.com",
                Email = "kayky-client@gmail.com",
                NormalizedUserName = "KAYKY-CLIENT@GMAIL.COM",
                NormalizedEmail = "KAYKY-CLIENT@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                Config.Student).GetAwaiter().GetResult();
            IdentityResult clientClaims = _user.AddClaimsAsync(client,
            [
                new(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new(JwtClaimTypes.GivenName, client.FirstName),
                new(JwtClaimTypes.FamilyName, client.LastName),
                new (JwtClaimTypes.Role, Config.Student)
            ]).Result;

            ApplicationUser employer = new()
            {
                UserName = "kayky-employer@gmail.com",
                NormalizedUserName = "KAYKY-EMPLOYER@GMAIL.COM",
                NormalizedEmail = "KAYKY-EMPLOYER@GMAIL.COM",
                Email = "kayky-employer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (11) 11111-1111",
                FirstName = "kayky",
                LastName = "Employer"
            };

            _user.CreateAsync(employer, "Kayky123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(employer,
                Config.Employer).GetAwaiter().GetResult();
            IdentityResult employerClaims = _user.AddClaimsAsync(employer,
            [
                new Claim(JwtClaimTypes.Name, $"{employer.FirstName} {employer.LastName}"),
                new Claim(JwtClaimTypes.GivenName, employer.FirstName),
                new Claim(JwtClaimTypes.FamilyName, employer.LastName),
                new Claim(JwtClaimTypes.Role, Config.Student)
            ]).Result;
        }

    }
}
