using System.Data.Common;

namespace Tickety.Modules.Events.Application.Abstraction.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync();
}
