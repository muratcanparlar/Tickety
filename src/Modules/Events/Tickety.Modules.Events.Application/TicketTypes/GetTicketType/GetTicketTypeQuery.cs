using Tickety.Modules.Events.Application.Abstraction.Messaging;

namespace Tickety.Modules.Events.Application.TicketTypes.GetTicketType;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<TicketTypeResponse>;