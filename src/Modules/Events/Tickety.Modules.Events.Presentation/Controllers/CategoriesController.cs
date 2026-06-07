using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tickety.Modules.Events.Application.Categories.ArchiveCategory;
using Tickety.Modules.Events.Application.Categories.CreateCategory;
using Tickety.Modules.Events.Application.Categories.GetCategories;
using Tickety.Modules.Events.Application.Categories.GetCategory;
using Tickety.Modules.Events.Application.Categories.UpdateCategory;
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
    public async Task<IActionResult> GetById(Guid id) 
    {
        Result<CategoryResponse> result = await sender.Send(new GetCategoryQuery(id));

        return result.Match<CategoryResponse, IActionResult>(
            category => Ok(category),
            r => ProblemResults.Problem(r));
    }

    [HttpPut("{id:guid}/archive")]
    public async Task<IActionResult> ArchiveCategory(Guid id)
    {
        Result result = await sender.Send(new ArchiveCategoryCommand(id));

        return result.Match<IActionResult>(
            () => Ok(),
            r => ProblemResults.Problem(r));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery());

        return result.Match<IReadOnlyCollection<CategoryResponse>, IActionResult>(
            categories => Ok(categories),
            r => ProblemResults.Problem(r));
    }

    [HttpPut("{id:guid}/")]
    public async Task<IActionResult> UpdateCategory (Guid id, [FromBody] UpdateCategoryRequest request)
    {
        Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

        return result.Match<IActionResult>(
            () => Ok(),
            r => ProblemResults.Problem(r));
    }
}
