using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Tickety.Modules.Events.Application.Abstraction.Clock;
using Tickety.Modules.Events.Application.Abstraction.Data;
using Tickety.Modules.Events.Domain.Categories;
using Tickety.Modules.Events.Domain.Events;
using Tickety.Modules.Events.Infrastructure.Categories;
using Tickety.Modules.Events.Infrastructure.Clock;
using Tickety.Modules.Events.Infrastructure.Data;
using Tickety.Modules.Events.Infrastructure.Events;

namespace Tickety.Modules.Events.Infrastructure;

public static class EventsServiceCollectionExtensions
{
    /// <summary>
    /// Registers persistence services for the Events module.
    /// </summary>
    public static IServiceCollection AddEventsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string for Events module was not found.");
        }

            services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.TryAddSingleton<IDbConnectionFactory, DbConnectionFactory>();

        services.AddSingleton(provider => new NpgsqlDataSourceBuilder(connectionString).EnableDynamicJson().Build());

        services.AddDbContext<EventsDbContext>((provider, opt) => opt
            .UseNpgsql(provider.GetRequiredService<NpgsqlDataSource>())
            .UseSnakeCaseNamingConvention()
            .AddInterceptors()
        );

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
