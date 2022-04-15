using Application.DTOs.GuideDTOs;

namespace Application.DTOs.CategoryDTOs;

public class CategoryWithGuidesDto
{
    public CategoryDto? Category { get; set; }
    public ICollection<GuideHeaderDto> Guides { get; set; }
}