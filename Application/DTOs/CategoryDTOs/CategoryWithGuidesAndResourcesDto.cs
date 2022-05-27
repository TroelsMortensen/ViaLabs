using Application.DTOs.ExternalResourceDTOs;
using Application.DTOs.GuideDTOs;

namespace Application.DTOs.CategoryDTOs;

public class CategoryWithGuidesAndResourcesDto
{
    public CategoryDto? Category { get; set; }
    public ICollection<GuideHeaderDto> Guides { get; set; } = null!;
    public ICollection<ExternalResourceDisplayDto> ExternalResources { get; set; }
}