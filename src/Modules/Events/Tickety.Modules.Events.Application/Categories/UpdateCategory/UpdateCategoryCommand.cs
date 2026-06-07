using Tickety.Modules.Events.Application.Abstraction.Messaging;

namespace Tickety.Modules.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;

