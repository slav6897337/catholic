using Catholic.Api.Filters;
using Catholic.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Catholic.Api.Apis;

public static class ImagesApi
{
    public static void MapImagesApi(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/images", (ImagesService imagesService) =>
            imagesService.GetImagesAsync());

        endpoints.MapGet("/api/images/{name}", (HttpContext context, string name) =>
        {
            var file = File.OpenRead($"./images/{name}");
            context.Response.RegisterForDisposeAsync(file);
            new FileExtensionContentTypeProvider().TryGetContentType(name, out var type);
            
            return Results.File(file, $"image/{type}", file.Name);
        }).DisableAntiforgery();
        
        endpoints.MapPost("/api/images",
            async (ImagesService imagesService,
                [FromForm] IFormFileCollection collection,
                [FromQuery] int? resizeWidth,
                [FromQuery] int? resizeHeight) =>
            {
                using var memoryStream = new MemoryStream();
                var file = collection.FirstOrDefault() ?? throw new("File not found");

                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                var newFileName = await imagesService.UploadImageAsync(file.FileName, memoryStream, resizeWidth, resizeHeight);
                return $"/images/{newFileName}";
            }).AdminAuthorization().DisableAntiforgery();
        
        endpoints.MapDelete("/api/images/{name}", (ImagesService imagesService, string name) =>
            imagesService.DeleteAsync(name)).AdminAuthorization();
    }
}