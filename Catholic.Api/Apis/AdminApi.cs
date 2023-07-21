using System.Diagnostics;
using System.Security.Claims;
using Catholic.Api.Filters;
using Catholic.Core.Helpers;

namespace Catholic.Api.Apis;

public static class AdminApi
{
    public static void MapAdminApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/health");

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
        
        endpoints.MapGet("/api/update", () =>
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "/scripts/docker-update.sh",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            
            return "Done";
        }).SystemAuthorization();
    }
}