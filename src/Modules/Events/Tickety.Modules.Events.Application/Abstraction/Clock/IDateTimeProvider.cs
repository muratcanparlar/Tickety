namespace Tickety.Modules.Events.Application.Abstraction.Clock;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}