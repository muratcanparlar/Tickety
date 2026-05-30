
namespace Tickety.Modules.Events.Contracts.Request;

public class CreateEventRequest
{
    public string Title { get; init; }

    public string Description { get; init; }

    public string Location { get; init; }

    public DateTime StartsAtUtc { get; init; }

    public DateTime? EndsAtUtc { get; init; }
}
