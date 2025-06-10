using Microsoft.EntityFrameworkCore;
using Serilog;
using EasyPOS.Backoffice.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("POSDbConn"), sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                          // Maximum number of retries
            maxRetryDelay: TimeSpan.FromSeconds(3),    // Maximum delay between retries
            errorNumbersToAdd: new List<int> {4060,    // Cannot open database requested by the login
                                              40197,   // The service has encountered an error processing your request
                                              40501,   // The service is currently busy. Retry the request after a few seconds
                                              10060,   // A timeout occurred while attempting to connect to the server
                                              -2});    // Timeout expired. The timeout period elapsed prior to obtaining a connection from the pool
    });
});

// Configure Serilog
Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .Build())
   .Enrich.FromLogContext()
   .CreateLogger();

// Use Serilog for logging
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
