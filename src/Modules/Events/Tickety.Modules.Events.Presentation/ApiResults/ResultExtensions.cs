using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tickety.Modules.Events.Domain.Abstractions;

namespace Tickety.Modules.Events.Presentation.ApiResults;

public static class ResultExtensions
{
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }

    public static IActionResult ToActionResult(this Result result)
    {
        return result.IsSuccess ? new OkResult() : ProblemResults.Problem(result);
    }

    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.IsSuccess ? new ObjectResult(result.Value) { StatusCode = StatusCodes.Status200OK } : ProblemResults.Problem(result);
    }
}
