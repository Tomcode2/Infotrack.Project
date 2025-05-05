using Infotrack.FrequencyFinder.Core;
using Infotrack.FrequencyFinder.Core.Repositories;
using Infotrack.FrequencyFinder.Data;
using Infotrack.FrequencyFinder.Data.Repositories;
using Infotrack.FrequencyFinder.Service.Abstraction;
using Infotrack.FrequencyFinder.Services;
using Infotrack.FrequencyFinder.Web.EngineService;
using Infotrack.FrequencyFinder.Web.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<SearchDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InfoTrackConnString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<IUIValidator, UIValidator>();
builder.Services.AddTransient<ISearchValidator, SearchValidator>();
builder.Services.AddTransient<ISearchEngineFactory, SearchEngineFactory>();

builder.Services.AddTransient<GoogleEngineService>();
builder.Services.AddTransient<BingEngineService>();
builder.Services.AddTransient<YahooEngineService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Use the logging lib for file logging
//builder.Logging.AddFile(options =>
//{
//    options.Path = "Logs/app-log-{Date}.txt";
//    options.Append = true; // Optional: Appends to the log file instead of overwriting
//});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Search}/{action=Index}/{id?}");

app.Run();

