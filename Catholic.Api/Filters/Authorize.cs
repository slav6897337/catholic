namespace Catholic.Api.Filters;

public static class Authorize
{
    public const string TokenType = "TokenType";
    public const string AdminToken = "AdminToken";
    public const string SystemToken = "SystemToken";

    public static TBuilder AdminAuthorization<TBuilder>(this TBuilder builder)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.RequireAuthorization(p => p.RequireClaim(TokenType, AdminToken));
        
        return builder;
    }
    
    public static TBuilder SystemAuthorization<TBuilder>(this TBuilder builder)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.RequireAuthorization(p => p.RequireClaim(TokenType, SystemToken));
        
        return builder;
    }
}