using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tickety.Modules.Events.Application.Persistence;
using Npgsql;

namespace Tickety.Modules.Events.Infrastructure
{
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

            services.AddSingleton(provider => new NpgsqlDataSourceBuilder(connectionString).EnableDynamicJson().Build());

            services.AddDbContext<EventsDbContext>((provider, opt) => opt
                .UseNpgsql(provider.GetRequiredService<NpgsqlDataSource>())
                .UseSnakeCaseNamingConvention()
            );

            services.AddScoped<IEventsDbContext>(sp => sp.GetRequiredService<EventsDbContext>());

            return services;
        }
    }
}
