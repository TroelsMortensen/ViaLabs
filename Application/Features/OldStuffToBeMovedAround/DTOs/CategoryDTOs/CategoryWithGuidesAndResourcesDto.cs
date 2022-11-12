using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;

namespace Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

public record CategoryWithGuidesAndResourcesDto(CategoryDto? Category, 
    ICollection<GuideHeaderDto> Guides,
    ICollection<ExternalResourceDisplayDto> ExternalResources);