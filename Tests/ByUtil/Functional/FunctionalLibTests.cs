using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;
using Domain.Utils;
using Domain.Values;

namespace Tests.ByUtil.Functional;

public class FunctionalLibTests
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    // [Fact]
    public async void AsyncMap()
    {
        Guid id = Guid.NewGuid();
        // Result<Category> existingCategoryResult = await categoryRepo.GetAsync(id)
        //         .IfSuccess(
        //             (r) =>
        //                 new Result<Category>(r.Value.Update("hello ", "#123456"))
        //         )
        //         .IfSuccess(
        //             (r) =>
        //             {
        //                 unitOfWork.SaveChangesAsync();
        //                 return r;
        //             }
        //         )
        //     ;
        // var catBeingUpdated = existingCategoryResult.Value;
        // Result result = catBeingUpdated.Update("hello ", "#123456");
    }
}