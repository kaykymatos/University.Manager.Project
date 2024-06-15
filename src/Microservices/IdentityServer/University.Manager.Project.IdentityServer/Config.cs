using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace University.Manager.Project.IdentityServer;

public static class Config
{
    public const string Admin = "Admin";
    public const string Student = "Student";
    public const string Employer = "Employer";
    public static IEnumerable<IdentityResource> IdentityResources =>
       [
            new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
       ];
    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new ApiScope("university", "University"),
            new ApiScope("read", "Reade data"),
            new ApiScope("write", "Write data"),
            new ApiScope("delete", "Delete data"),
        ];

    public static IEnumerable<Client> Clients =>
        [
            new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Environment.GetEnvironmentVariable("SecretIdentity").Sha256())
                    }, AllowedScopes = {"read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "university",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = {new Secret(Environment.GetEnvironmentVariable("SecretIdentity").Sha256())},
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "university" }
                },
            ];
}
