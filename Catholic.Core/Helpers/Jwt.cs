using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Catholic.Core.Helpers;

public static class Jwt
{
    public const string ExpirationClaimType = "exp";
    
    public static string Create(string secret, IEnumerable<Claim> claims, DateTime expiration)
    {
        ArgumentException.ThrowIfNullOrEmpty(secret, nameof(secret));
        if(secret.Length < 16) throw new Exception("Secret must be at least 16 characters long");
     

        var key = Encoding.ASCII.GetBytes(secret);
        var handler = new JwtSecurityTokenHandler();
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = (JwtSecurityToken)handler.CreateToken(descriptor);

        return token.RawData;
    }

    public static List<Claim> Read(string secret, string jwt,
        bool throwUnauthorized = true,
        bool validateAudience = false,
        bool validateIssuer = false,
        bool validateExpiration = false)
    {
        try
        {
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();

            handler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = validateAudience,
                ValidateIssuer = validateIssuer
            }, out var token);

            var jwtToken = (JwtSecurityToken)token;

            if (!validateExpiration || token.ValidTo > DateTime.UtcNow)
            {
                return jwtToken.Claims.ToList();
            }
        }
        catch (Exception ex)
        {
            L.Warning(ex, "Error reading JWT");
        }

        if (throwUnauthorized)
        {
            throw  new UnauthorizedAccessException("Request is unauthorized");
        }

        return new List<Claim>();
    }
}