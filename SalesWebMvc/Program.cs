using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SalesWebAPI.Data;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext")),
    builder => builder.MigrationsAssembly("SalesWebMvc")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartamentService>();
builder.Services.AddScoped<SalesRecordService>();
builder.Services.AddScoped<NotesService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
var enUS = new CultureInfo("en-US");
var localizationOption = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS },
};

app.UseRequestLocalization(localizationOption);

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Injetando o SeedingService no pipeline de solicita��o
// Aqui n�s estamos dizendo para o aplicativo executar um peda�o de c�digo somente se uma certa condi��o for verdadeira.
app.MapWhen(context =>
{
    // Aqui, estamos verificando em qual ambiente o aplicativo est� rodando, se � "desenvolvimento" ou n�o.
    var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

    // Se o aplicativo estiver em ambiente de "desenvolvimento"...
    if (env.IsDevelopment())
    {
        // Aqui, estamos dizendo para o aplicativo pegar um servi�o que semeia dados e chamar um m�todo nele chamado "Seed".
        var seedingService = context.RequestServices.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }

    // Aqui estamos dizendo que, independentemente de estar em ambiente de desenvolvimento ou n�o,
    // n�o vamos interromper o fluxo normal do aplicativo, ent�o estamos retornando "false".
    return false;
}, app => { });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            // Call the SeedingService to seed the data
            var seedingService = services.GetRequiredService<SeedingService>();
            seedingService.Seed();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
        }
    }
}
app.Run();
