using Application.DTOs.GuideDTOs;

namespace Application.ProviderContracts;

public interface IGuideProvider
{
    Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher);
}