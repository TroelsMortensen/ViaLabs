using Domain.Entities;

namespace ViewData.ProfileInfo.DTOs;

public class GuideDataVM
{
    public Guid GuideId { get; set; }
    public string Title { get; set; }
    // public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }

    public string Description { get; set; }
    public bool StepNumbersVisible { get; set; }

    public bool IsPublished { get; set; }
    
    public ICollection<SlideStep> Slides { get; set; }

    public ICollection<CategoryVM> CategoriesByTeacher { get; set; }
}