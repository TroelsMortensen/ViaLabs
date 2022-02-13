using Entities;

namespace Application.DTOs;

public class PersonalCategoriesOverview
{
    public IList<CategoriesWithGuidesOverviewDto> Categories { get; set; }
}