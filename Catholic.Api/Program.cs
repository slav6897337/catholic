using Catholic.Api;
using Catholic.Core.Clients;
using Catholic.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<BibleService>();
builder.Services.AddScoped<BibleClient>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.MapApi();

app.Run("http://*:5000");