
namespace Catholic.Core.Services;

public class ImagesService
{
    public ImagesService()
    {
    }
    
    public async Task<string[]> GetImagesAsync()
    {
        return Directory.GetFiles("app/images");
    }


    public async Task UploadImageAsync(string fileName, MemoryStream memoryStream)
    {
        if (Directory.Exists("app/images") == false)
        {
            Directory.CreateDirectory("app/images");
        }
        
        await using var file = File.OpenWrite($"app/images/{fileName}");
        await memoryStream.CopyToAsync(file);
    }

    public void DeleteAsync(string name)
    {
        Directory.Delete($"app/images/{name}", true);
    }
}