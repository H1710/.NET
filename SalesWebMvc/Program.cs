using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: false,
        reloadOnChange: true
     ).AddEnvironmentVariables();

// Configure the database context and migration assembly
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext")),
    migrationOptions => migrationOptions.MigrationsAssembly("SalesWebMvc")));

// Add services to the DI container
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartamentService>();
builder.Services.AddScoped<SalesRecordService>();
builder.Services.AddScoped<NotesService>();

// Add controller and view services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure request localization
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS },
};

app.UseRequestLocalization(localizationOptions);

// Middleware configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SalesWebMvcContext>();

// Apply any pending migrations
context.Database.Migrate();

// Seed the database
var seedingService = services.GetRequiredService<SeedingService>();
seedingService.Seed();

// Map the default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
