using Tickety.Modules.Events.Application.Abstraction.Clock;

namespace Tickety.Modules.Events.Infrastructure.Clock;

public sealed class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
