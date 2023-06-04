using Catholic.Api;
using Catholic.Core.Clients;
using Catholic.Core.Services;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<BibleService>();
builder.Services.AddScoped<BibleClient>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapApi();

app.MapFallbackToFile("index.html");

app.Run("http://*:5000");