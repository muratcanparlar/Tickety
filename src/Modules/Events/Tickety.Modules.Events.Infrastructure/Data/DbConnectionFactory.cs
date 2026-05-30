using Npgsql;
using System.Data.Common;
using Tickety.Modules.Events.Application.Abstraction.Data;

namespace Tickety.Modules.Events.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
