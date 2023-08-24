
namespace Catholic.Core.Services;

public class ImagesService
{
    public ImagesService()
    {
    }
    
    public async Task<string[]> GetImagesAsync()
    {
        return Directory.GetFiles("./images");
    }
    
    public async Task<string[]> ListFilesAsync()
    {
        return Directory.GetFiles("./");
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