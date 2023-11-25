using Catholic.Api.Filters;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class AdminApi
{
    
    public static void MapAdminApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/health", () => new ApiStatus("OK"));

        endpoints.MapPost("/api/admins/token", async (AdminInfo adminInfo, AdminService service) =>
        {
            var admin = await service.GetAdminAsync(adminInfo);
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
        
        
        // endpoints.MapGet("/api/admins/system/token", (AdminService service) =>
        // {
        //     var token =  service.GenerateSystemToken();
        //     return token;
        // });
    }
}