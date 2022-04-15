using Application.DTOs.CategoryDTOs;
using Application.DTOs.GuideDTOs;

namespace Application.DTOs;

public class ProfileDataDto
{
    public Dictionary<CategoryDto, ICollection<GuideHeaderDto>> Categories { get; }

    public ProfileDataDto(Dictionary<CategoryDto, ICollection<GuideHeaderDto>> categories)
    {
        Categories = categories;
    }
}