using System.Collections.ObjectModel;
using Entities;

namespace Application.DTOs;

public class CategoriesWithGuidesOverviewDto
{
    public ICollection<CategoryDto> Categories { get; set; }
}