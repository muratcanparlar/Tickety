using Tickety.Modules.Events.Application.Abstraction.Messaging;

namespace Tickety.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

public sealed record UpdateTicketTypePriceCommand(Guid TicketTypeId, decimal Price) : ICommand;

