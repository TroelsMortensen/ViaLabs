using Application.DTOs.GuideDTOs;
using Application.Providers;
using Entities;

namespace JsonData.ProviderImpls;

public class JsonGuideProvider : IGuideProvider
{
    public Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher)
    {
        throw new NotImplementedException();
    }
}