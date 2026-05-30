using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local";

if (environment == "Local")
{
    builder.AddUserSecrets<Program>();
}

var configuration = builder.Build();
string connectionString = configuration["TicketyDB"];

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine("Connection string not found.");
    Console.ResetColor();
    return 1;
}

var upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .WithTransaction()
    .LogToConsole()
    .Build();

try
{
    var result = upgrader.PerformUpgrade();

    if (!result.Successful)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine($"Migration failed: {result.Error}");
        Console.ResetColor();
        return 1;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Database migration completed successfully.");
    Console.ResetColor();
    return 0;
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine($"Migration failed with exception: {ex}");
    Console.ResetColor();
    return 1;
}
