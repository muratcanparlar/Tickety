

namespace Tickety.Modules.Events.Contracts.Request;

public class CreateCategoryReqeuest
{
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; } = false;
}
