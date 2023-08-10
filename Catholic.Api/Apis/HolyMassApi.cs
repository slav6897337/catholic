using Catholic.Api.Filters;
using Catholic.Core.Services;
using Catholic.Domain;

namespace Catholic.Api.Apis;

public static class HolyMassApi
{
    public static void MapHolyMassApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/holy-mass", (HolyMassService holyMassService) =>
            holyMassService.GetAllAsync(sortBy:m => m.Schedule));
        
        endpoints.MapPost("/api/holy-mass", (HolyMassService holyMassService, HolyMass holyMass) =>
            holyMassService.AddPageAsync(holyMass)).AdminAuthorization();
        
        endpoints.MapPut("/api/holy-mass/{id}", (HolyMassService holyMassService, string id, HolyMass holyMass) =>
            holyMassService.UpdatePageAsync(id, holyMass)).AdminAuthorization();
        
        endpoints.MapDelete("/api/holy-mass/{id}", (HolyMassService holyMassService, string id) =>
            holyMassService.DeleteAsync(id)).AdminAuthorization();
    }
}