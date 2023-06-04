using Catholic.Api;
using Catholic.Core.Clients;
using Catholic.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

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