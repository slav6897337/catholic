using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Catholic.Core.Services;

public class ImagesService
{
    public ImagesService()
    {
    }
    
    public async Task<string[]> GetImagesAsync()
    {
        var files = Directory.GetFiles("./images");
        files = files.Select(f => f.Replace("./", "/")).ToArray();
        return files;
    }
    
    public async Task<string> UploadImageAsync(string fileName, MemoryStream memoryStream, int? resizeWidth, int? resizeHeight)
    {
        if (Directory.Exists("./images") == false)
        {
            Directory.CreateDirectory("images");
        }
        
        var newFileName = fileName.LastIndexOf('.') switch
        {
            -1 => fileName,
            var index => $"{fileName[..index]}.webp"
        };
        
        using var image = await Image.LoadAsync(memoryStream);
        await image.SaveAsync($"./images/{newFileName}", new WebpEncoder());

        if (resizeWidth != null || resizeHeight != null)
        {
            resizeWidth ??= resizeHeight * image.Width / image.Height;
            resizeHeight ??= resizeWidth * image.Height / image.Width;
        
            image.Mutate(x => x
                .Resize(resizeWidth.Value, resizeHeight.Value));
            
            await image.SaveAsync($"./images/min_{newFileName}", new WebpEncoder());
        }

        return newFileName;
    }
    
    public void DeleteAsync(string name)
    {
        File.Delete($"./images/{name}");
        File.Delete($"./images/min_{name}");
    }
    
    private async Task ResizeImageAsync(string fileName, MemoryStream memoryStream, int? resizeWidth, int? resizeHeight)
    {
        if(resizeWidth == null && resizeHeight == null) return;
        memoryStream.Position = 0;
        using var image = await Image.LoadAsync(memoryStream);
        
        resizeWidth ??= resizeHeight * image.Width / image.Height;
        resizeHeight ??= resizeWidth * image.Height / image.Width;
        
        image.Mutate(x => x
            .Resize(resizeWidth.Value, resizeHeight.Value));

        await image.SaveAsync($"./images/min_{fileName}", new WebpEncoder());
    }
}