using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;

namespace Application.Features.ProfileDataLogic.ProviderContracts;

public interface IGuideProvider
{
    Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher);
}