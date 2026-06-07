using Tickety.Modules.Events.Application.Abstraction.Messaging;
using Tickety.Modules.Events.Application.Categories.GetCategory;

namespace Tickety.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;