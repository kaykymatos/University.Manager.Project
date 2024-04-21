using IdentityServer4;
using IdentityServer4.Models;

namespace University.Manager.Project.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Student = "Student";
        public const string Employer = "Employer";
        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
           };
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("university", "University"),
            new ApiScope("read", "Reade data"),
            new ApiScope("write", "Write data"),
            new ApiScope("delete", "Delete data"),
        };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Environment.GetEnvironmentVariable("secret").Sha256())
                    }, AllowedScopes = {"read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "university",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret(Environment.GetEnvironmentVariable("secret").Sha256())},
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                    AllowedScopes = {  
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "university" }
                },
            };
    }
}
