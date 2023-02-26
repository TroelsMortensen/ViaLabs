namespace ViewData.ProfileInfo.DTOs;

public class CategoryWithGuidesAndResourcesVM
{
    public CategoryVM Category { get; private set; }
    public ICollection<GuideHeaderVM> Guides { get; private set; }
    public ICollection<ExternalResourceDisplayVM> ExternalResources { get; private set; }

    public CategoryWithGuidesAndResourcesVM(CategoryVM category, ICollection<GuideHeaderVM> guides, ICollection<ExternalResourceDisplayVM> externalResources)
    {
        Category = category;
        Guides = guides;
        ExternalResources = externalResources;
    }
}