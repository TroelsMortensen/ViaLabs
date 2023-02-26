using Domain.Entities;

namespace ViewData.ProfileInfo.DTOs;

public class GuideDataVM
{
    public string Title { get; set; }
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }

    public string Description { get; set; }
    public bool ShowStepNumbers { get; set; }

    public bool IsPublished { get; set; }
    
    public ICollection<SlideDetails> Slides { get; set; }
}