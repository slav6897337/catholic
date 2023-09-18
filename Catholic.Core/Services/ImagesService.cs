
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class ImagesService
{
    private readonly IMemoryCache cache;

    public ImagesService(IMemoryCache cache)
    {
        this.cache = cache;
    }
    
    public async Task<string[]> GetImagesAsync()
    {
        var files = Directory.GetFiles("./images");
        files = files.Select(f => f.Replace("./", "/")).ToArray();
        return files;
    }
    
    public FileStream GetImageAsync(string name)
    {
        var cacheKey = $"ImageCache-{name}";
        var file = cache.GetOrCreate(cacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
            return File.OpenRead($"./images/{name}");
        });
        
        return file;
    }

    public async Task UploadImageAsync(string fileName, MemoryStream memoryStream)
    {
        if (Directory.Exists("./images") == false)
        {
            Directory.CreateDirectory("images");
        }
        
        await using var file = File.OpenWrite($"./images/{fileName}");
        await memoryStream.CopyToAsync(file);
    }

    public void DeleteAsync(string name)
    {
        Directory.Delete($"./images/{name}", true);
    }
}