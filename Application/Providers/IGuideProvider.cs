using Application.DTOs.GuideDTOs;
using Entities;

namespace Application.Providers;

public interface IGuideProvider
{
    Task<ICollection<GuideHeaderDto>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task<ICollection<GuideHeaderDto>> GetUnCategorizedByTeacherAsync(string teacher);
}