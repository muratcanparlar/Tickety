using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tickety.Modules.Events.Application.Events.CreateEvent;
using Tickety.Modules.Events.Contracts.Request;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Presentation.ApiResults;

namespace Tickety.Modules.Events.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        try
        {
            Result<Guid> result = await sender.Send(new CreateEventCommand(
           request.CategoryId,
           request.Title,
           request.Description,
           request.Location,
           request.StartsAtUtc,
           request.EndsAtUtc));

            return result.Match<Guid, IActionResult>(
                id => CreatedAtAction(nameof(GetById), new { id }, new { id }),
                r => ProblemResults.Problem(r));
        }
        catch (Exception ex)
        {

            throw ex;
        }
       
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id) => NotFound();
}
