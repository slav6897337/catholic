using System.Text;
using Catholic.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace Catholic.Api;

public static class AppExtensions
{
    public static void AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opts =>
            {
                opts.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => Task.CompletedTask,
                    OnTokenValidated = context => Task.CompletedTask,
                    OnChallenge = context => throw new UnauthorizedAccessException("Request is unauthorized")
                };

                opts.RequireHttpsMetadata = true;
                opts.SaveToken = true;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtSecret")!)),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    RequireExpirationTime = false
                };
            });
        
        services.AddAuthorization();
    }

    public static void AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowLocalhost",
                pol =>
                {
                    pol.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    
                    pol.WithOrigins("https://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    
                    pol.WithOrigins("https://91.92.136.124")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    
                    pol.WithOrigins("http://91.92.136.124")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }

    public static void UseCustomCors(this IApplicationBuilder app)
    {
        app.UseCors("AllowLocalhost");
    }

    public static void UseExHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(c => c.Run(async context =>
        {
            var exception = context.Features.Get<IExceptionHandlerPathFeature>()!.Error;

            L.Error(exception, exception.Message);
            L.Error($"{context.Request.Method}: {context.Request.Path}");

            await context.Response.WriteAsync($"""
                {exception.Message}

                {exception.InnerException?.Message}

                {exception.StackTrace}
                """);
        }));
    }
}