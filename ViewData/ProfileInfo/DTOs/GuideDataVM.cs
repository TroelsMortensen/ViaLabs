namespace ViewData.ProfileInfo.DTOs;

public class GuideDataVM
{
    private IList<SlideStepVM> slides;
    public Guid GuideId { get; set; }
    public string Title { get; set; }
    // public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }

    public string Description { get; set; } = "";
    public bool StepNumbersVisible { get; set; }

    public bool IsPublished { get; set; }

    public IList<SlideStepVM> Slides
    {
        get => slides.OrderBy(vm => vm.Index).ToList();
        set => slides = value;
    }

    public ICollection<CategoryVM> CategoriesByTeacher { get; set; }
}