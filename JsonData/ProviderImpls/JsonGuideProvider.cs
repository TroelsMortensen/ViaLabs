using System.Collections.ObjectModel;
using Application.DTOs.GuideDTOs;
using Application.Providers;
using Entities;
using JsonData.DataAccess;

namespace JsonData.ProviderImpls;

public class JsonGuideProvider : IGuideProvider
{

    private readonly JsonDataContext context;


    public JsonGuideProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        ICollection<GuideHeaderDto> list = context.ViaLabData.Guides.
            Where(g => g.CategoryId.Equals(categoryId)).
            Select(g => new GuideHeaderDto(g.Id, g.Title)).
            ToList();
        
        return Task.FromResult(list);
    }

    public Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher)
    {
        ICollection<GuideHeaderDto> list = context.ViaLabData.Guides.
            Where(g => g.CategoryId is null).
            Select(g => new GuideHeaderDto(g.Id, g.Title)).
            ToList();
        
        return Task.FromResult(list); 
    }
}