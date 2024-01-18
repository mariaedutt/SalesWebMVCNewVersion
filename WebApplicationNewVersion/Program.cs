using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using WebApplicationNewVersion.Data;
using WebApplicationNewVersion.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplicationNewVersionContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("WebApplicationNewVersionContext"),
    new MySqlServerVersion(new Version(8, 0, 28)), // Substitua pela versão do seu servidor MySQL
    builder => builder.MigrationsAssembly("WebApplicationNewVersion")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo>() { enUS }
};

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
// Crie um escopo para resolver o serviço SeedingService
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Resolva o serviço SeedingService
    var seed = services.GetRequiredService<SeedingService>();

    // Chame o método Seed
    seed.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
