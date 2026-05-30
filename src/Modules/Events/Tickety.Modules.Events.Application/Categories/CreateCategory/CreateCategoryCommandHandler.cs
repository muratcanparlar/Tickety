using Tickety.Modules.Events.Application.Abstraction.Data;
using Tickety.Modules.Events.Application.Abstraction.Messaging;
using Tickety.Modules.Events.Domain.Abstractions;
using Tickety.Modules.Events.Domain.Categories;

namespace Tickety.Modules.Events.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = Category.Create(request.Name);

            categoryRepository.Insert(category);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
        catch (Exception ex)
        {

            throw;
        }
       
    }
}