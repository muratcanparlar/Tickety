using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Domain.Events;

public static class EventErrors
{
    public static readonly Error EndDatePrecedesStartDate = Error.Problem(
        "Events.EndDatePrecedesStartDate",
        "The event end date precedes the start date");

    public static readonly Error StartDateInPast = Error.Problem(
       "Events.StartDateInPast",
       "The event start date is in the past");
}
