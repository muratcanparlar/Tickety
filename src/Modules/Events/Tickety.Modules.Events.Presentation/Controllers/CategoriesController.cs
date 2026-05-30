using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tickety.Modules.Events.Application.Categories.CreateCategory;
using Tickety.Modules.Events.Contracts.Request;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Presentation.ApiResults;


namespace Tickety.Modules.Events.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryReqeuest request)
    {
        Result<Guid> result = await sender.Send(new CreateCategoryCommand(request.Name));

        return result.Match<Guid, IActionResult>(
           id => CreatedAtAction(nameof(GetById), new { id }, new { id }),
           r => ProblemResults.Problem(r));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id) => NotFound();
}
