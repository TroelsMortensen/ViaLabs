using Application.Features.ProfileDataLogic.ProviderContracts;
using JsonData.Context;

namespace JsonData.ProviderImpls.ProfileInfoProviderImpls;

internal class JsonGuideProvider : IGuideProvider
{

    private readonly JsonDataContext context;


    internal JsonGuideProvider(JsonDataContext context)
    {
        this.context = context;
    }

    // public Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId)
    // {
    //     ICollection<GuideHeaderDto> list = context.Categories.First(c => c.Id.Equals(categoryId)).Guides.Select(g => new GuideHeaderDto())
    //     
    //     return Task.FromResult(list);
    // }

    // public Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher)
    // {
    //     ICollection<GuideHeaderDto> list = context.Guides.
    //         Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher)).
    //         Select(g => new GuideHeaderDto(g.Id, g.Title)).
    //         ToList();
    //     
    //     return Task.FromResult(list); 
    // }
}