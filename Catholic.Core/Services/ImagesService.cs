
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
        File.Delete($"./images/{name}");
    }
}