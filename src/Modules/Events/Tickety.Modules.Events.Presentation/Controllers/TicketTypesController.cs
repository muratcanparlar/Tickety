using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tickety.Modules.Events.Application.TicketTypes.CreateTicketType;
using Tickety.Modules.Events.Application.TicketTypes.GetTicketType;
using Tickety.Modules.Events.Application.TicketTypes.GetTicketTypes;
using Tickety.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;
using Tickety.Modules.Events.Contracts.Request;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Presentation.ApiResults;

namespace Tickety.Modules.Events.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketTypesController(ISender sender) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketTypeRequest request)
    {
        Result<Guid> result = await sender.Send(new CreateTicketTypeCommand(
        request.EventId,
        request.Name,
        request.Price,
        request.Currency,
        request.Quantity));

        return result.Match<Guid, IActionResult>(
            id => CreatedAtAction(nameof(GetByIdAsync), new { id }, new { id }),
            r => ProblemResults.Problem(r));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        Result<TicketTypeResponse> result = await sender.Send(new GetTicketTypeQuery(id));

        return result.Match<TicketTypeResponse, IActionResult>(
            ticketType => Ok(ticketType),
            r => ProblemResults.Problem(r));
    }

    [HttpGet("event/{eventId:guid}")]
    public async Task<IActionResult> GetByEventIdAsync(Guid eventId)
    {
        Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(new GetTicketTypesQuery(eventId));

        return result.Match<IReadOnlyCollection<TicketTypeResponse>, IActionResult>(
            ticketTypes => Ok(ticketTypes),
            r => ProblemResults.Problem(r));
    }

    [HttpPut("{id:guid}/price")]
    public async Task<IActionResult> UpdatePriceAsync(Guid id, [FromBody] UpdateTicketTypePriceRequest request)
    {
        Result result = await sender.Send(new UpdateTicketTypePriceCommand(id, request.Price));
        return result.Match(
            () => NoContent(),
            r => ProblemResults.Problem(r));
    }
}
