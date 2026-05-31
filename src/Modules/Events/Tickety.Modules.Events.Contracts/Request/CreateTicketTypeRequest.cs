namespace Tickety.Modules.Events.Contracts.Request;

public class CreateTicketTypeRequest
{
    public Guid EventId { get; init; }

    public string Name { get; init; }

    public decimal Price { get; init; }

    public string Currency { get; init; }

    public int Quantity { get; init; }
}
