using AI_driven_OSINT_platform.Backend.Features.Authentication.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Debug: Verify the connection string
var connectionString = configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Error: Connection string 'DefaultConnection' is not set or empty.");
    throw new InvalidOperationException("The connection string is not configured properly.");
}
Console.WriteLine($"Connection String: {connectionString}");

// Register DbContext with the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        // Specify the migrations assembly
        sqlOptions.MigrationsAssembly("AI_driven_OSINT_platform");
    })
);

// Register other services here
builder.Services.AddControllers(); // Add MVC controller support

// Optional: Register AppSettings
builder.Services.Configure<AI_driven_OSINT_platform.Backend.Configurations.AppSettings>(configuration.GetSection("AppSettings"));

var app = builder.Build();

// Middleware configuration
app.UseRouting();
app.UseAuthorization(); // Add if needed for secured endpoints

// Map endpoints
app.MapControllers();
app.MapGet("/", () => "Hello World!"); // Example endpoint

// Run the application
try
{
    Console.WriteLine("Starting the application...");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Application failed to start: {ex.Message}");
    throw;
}
