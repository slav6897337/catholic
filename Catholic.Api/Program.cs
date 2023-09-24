using Catholic.Api;
using Catholic.Api.Apis;
using Catholic.Core.Clients;
using Catholic.Core.Helpers;
using Catholic.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.CleanupDefaultLogging();
L.Info("Starting up Catholic.Api");

Env.Load();

builder.Services.AddAuth();

builder.Services.AddCustomCors();

builder.Services.AddHttpClient();

builder.Services.AddScoped<BibleService>();
builder.Services.AddScoped<NotesService>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<PagesService>();
builder.Services.AddScoped<HolyMassService>();
builder.Services.AddScoped<ImagesService>();
builder.Services.AddScoped<AdminService>();

builder.Services.AddScoped<BibleClient>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseCustomCors();
app.UseExHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapBibleApi();
app.MapNotesApi();
app.MapNewsApi();
app.MapPagesApi();
app.MapHolyMassApi();
app.MapImagesApi();
app.MapAdminApi();

app.Run("http://*:5000");