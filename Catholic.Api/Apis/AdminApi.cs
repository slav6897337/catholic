using Catholic.Api.Filters;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class AdminApi
{
    
    public static void MapAdminApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/health", () => new {Status = "OK"});

        endpoints.MapGet("/api/admins/token", async (string name, string pass, AdminService service) =>
        {
            var admin = await service.GetAdminAsync(name, pass);
            return admin;
        });
        
        endpoints.MapGet("/api/admins", async (AdminService service) =>
        {
            var admins = await service.ListAdminsAsync();
            return admins;
        }).SystemAuthorization();
        
        endpoints.MapPost("/api/admins", async (AdminInfo admin, AdminService service) =>
        {
            var adminInfo = await service.CreateAdminAsync(admin);
            return adminInfo;
        }).SystemAuthorization();
        
            
        endpoints.MapPut("/api/admins/id", async (string id, AdminInfo admin, AdminService service) =>
        {
            var adminInfo = await service.UpdateAdminAsync(id, admin);
            return adminInfo;
        }).SystemAuthorization();
    }
}