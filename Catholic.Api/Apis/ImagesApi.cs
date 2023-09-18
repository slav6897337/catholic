using System.Net.Mime;
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

        endpoints.MapGet("/api/images/{name}", (HttpContext context, ImagesService imagesService, string name) =>
        {
            var file = imagesService.GetImageAsync(name);
            context.Response.RegisterForDisposeAsync(file);
            
            new FileExtensionContentTypeProvider().TryGetContentType(name, out var type);
            
            return Results.File(file, $"image/{type}", file.Name);
        });
        
        endpoints.MapPost("/api/images",
            async (ImagesService imagesService, [FromForm] IFormFileCollection collection) =>
            {
                using var memoryStream = new MemoryStream();
                var file = collection.FirstOrDefault() ?? throw new("File not found");

                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                await imagesService.UploadImageAsync(file.FileName, memoryStream);
                return file.FileName;
            }).AdminAuthorization();
        
        endpoints.MapDelete("/api/images/{name}", (ImagesService imagesService, string name) =>
            imagesService.DeleteAsync(name)).AdminAuthorization();
    }
}