using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;

namespace Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

public class CategoryWithGuidesAndResourcesDto
{
    public CategoryDto? Category { get; set; }
    public ICollection<GuideHeaderDto> Guides { get; set; } = null!;
    public ICollection<ExternalResourceDisplayDto> ExternalResources { get; set; }
}