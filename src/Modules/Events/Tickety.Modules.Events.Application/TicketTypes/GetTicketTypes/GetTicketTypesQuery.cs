using Tickety.Modules.Events.Application.Abstraction.Messaging;
using Tickety.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Tickety.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;

