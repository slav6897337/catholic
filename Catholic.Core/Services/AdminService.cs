using System.Security.Claims;
using Catholic.Core.Helpers;
using Catholic.Core.Repositories;
using Catholic.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace Catholic.Core.Services;

public class AdminService : MongoRepository<AdminInfo>
{
    public const string TokenType = "TokenType";
    public const string AdminToken = "AdminToken";
    
    public AdminService(IMemoryCache cache) : base("Admins", cache)
    {
    }
    
    public async Task<AdminInfo?> GetAdminAsync(string name, string pass)
    {
        var admins = await GetAllAsync();
        
        var admin = admins?.FirstOrDefault(i => i.Name == name && i.Pass == pass)
            ?? throw new Exception("Invalid credentials");
        
        var jwtSecret = Environment.GetEnvironmentVariable("JwtSecret");
        var token = Jwt.Create(jwtSecret, new Claim[]
        {
            new Claim(TokenType, AdminToken)
        }, DateTime.UtcNow.AddYears(10));
        
        admin.Token = token;
        
        return admin;
    }

    public async Task<List<AdminInfo>> ListAdminsAsync()
    {
        var admins = await GetAllAsync();
        
        return admins ?? new List<AdminInfo>();
    }

    public async Task<AdminInfo> CreateAdminAsync(AdminInfo admin)
    {
        ArgumentException.ThrowIfNullOrEmpty(admin.Name);
        ArgumentException.ThrowIfNullOrEmpty(admin.Pass);
        
        var admins = await GetAllAsync();
        
        if (admins?.Any(a => a.Name== admin.Name && a.Pass == admin.Pass) == true)
        {
            throw new Exception($"Admin with name {admin.Name} already exists");
        }
        
        await collection.InsertOneAsync(admin);

        UpdateCacheInBackground();
          
        return admin;   
    }
    
    public async Task<AdminInfo> UpdateAdminAsync(string id, AdminInfo admin)
    {
        var admins = await GetAllAsync();

        if (admins?.FirstOrDefault(a => a.Id == id) == null)
        {
            throw new Exception("Admin not found");
        }
        
        await UpdateAsync(id, admin);

        return admin;   
    }
}