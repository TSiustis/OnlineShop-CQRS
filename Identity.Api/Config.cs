using System.Security.Claims;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Identity.Api;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new()
                {
                    Name = "role",
                    UserClaims = new List<string> { ClaimTypes.Role }
                }
            };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[]
        {
                new ApiScope("OnlineShop.Api.full"), new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
            new ApiResource("OnlineShop.Api","Online Shop API")
            {
                ApiSecrets = { new Secret("SuperSecretPassword".Sha256()) },
                Scopes = new List<string> { "OnlineShop.Api.full" },
                UserClaims={
                    JwtClaimTypes.Name,
                    JwtClaimTypes.Subject,
                    JwtClaimTypes.Profile,
                    JwtClaimTypes.Email,
                    JwtClaimTypes.Role
                }
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
                new Client
                {
                    ClientId = "online-shop",
                    ClientName = "OnlineShop.Api",

                    RedirectUris = { "https://localhost:7118/signin-oidc", "https://localhost:7118/", "https://localhost:7118/authentication/login-callback", "https://localhost:7065/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc"},

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "OnlineShop.Api.full", "role", IdentityServerConstants.LocalApi.ScopeName},

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },
                new Client
                {
                    ClientId = "online-shop",
                    ClientName = "OnlineShop.React",

                    RedirectUris = { "https://localhost:7118/signin-oidc", "https://localhost:7118/", "https://localhost:7118/authentication/login-callback", "https://localhost:7065/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc"},

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "OnlineShop.React.full", "role", IdentityServerConstants.LocalApi.ScopeName},

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                },

        };
}
