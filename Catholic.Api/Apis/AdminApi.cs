using System.Diagnostics;
using System.Security.Claims;
using Catholic.Api.Filters;
using Catholic.Core.Helpers;

namespace Catholic.Api.Apis;

public static class AdminApi
{
    public static void MapAdminApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/health", () => new {Status = "OK"});

        // endpoints.MapGet("/api/token", () =>
        // {
        //     var jwtSecret = Environment.GetEnvironmentVariable("JwtSecret");
        //     var token = Jwt.Create(jwtSecret, new Claim[]
        //     {
        //         new Claim(Authorize.TokenType, Authorize.SystemToken)
        //     }, DateTime.UtcNow.AddYears(10));
        //
        //     return token;
        // });
    }
}