namespace ViewData.ProfileInfo.DTOs;

public class CategoryWithGuidesAndResourcesDto
{
    public CategoryDto Category { get; private set; }
    public ICollection<GuideHeaderDto> Guides { get; private set; }
    public ICollection<ExternalResourceDisplayDto> ExternalResources { get; private set; }

    public CategoryWithGuidesAndResourcesDto(CategoryDto category, ICollection<GuideHeaderDto> guides, ICollection<ExternalResourceDisplayDto> externalResources)
    {
        Category = category;
        Guides = guides;
        ExternalResources = externalResources;
    }
}