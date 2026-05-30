
namespace Tickety.Modules.Events.Domain.Event
{
    public class Event
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public DateTimeOffset StartsAtUtc { get; set; }
        public DateTimeOffset EndsAtUtc { get; set; }
        public required string Status { get; set; }
    }
}
