using Tickety.Modules.Events.Application.Abstraction.Messaging;

namespace Tickety.Modules.Events.Application.TicketTypes.CreateTicketType;

public sealed record CreateTicketTypeCommand(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    int Quantity) : ICommand<Guid>;
