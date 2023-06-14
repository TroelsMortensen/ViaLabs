using Domain.OperationResult;
using Domain.Values;

namespace Domain.Aggregates;

public class Guide
{
    private const int MAX_TITLE_LENGTH = 30;
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsDisplayingStepNums { get; private set; }

    public IList<Slide> Slides { get; private set; }

    public CategoryId CategoryId { get; private set; }

    public string TeacherId { get; private set; }
    public string Description { get; private set; }

    public static Result<Guide> Create(Guid guideId, string title, CategoryId categoryId, string teacherId)
    {
        Result validationResult = Validate(guideId, title, categoryId, teacherId);
        if (validationResult.IsFailure)
        {
            return Result.Failure<Guide>(validationResult.Errors);
        }

        Guide guide = new(guideId, title, categoryId, teacherId);
        return Result.Success(guide);
    }

    private static Result Validate(Guid guideId, string title, CategoryId categoryId, string teacherId)
    {
        Result result = new();

        if (categoryId == null)
        {
            result.AddError("Guide.CategoryId", "Category ID cannot be empty, a Guide must be associated with a Category.");
        }

        if (string.IsNullOrEmpty(teacherId))
        {
            result.AddError("Guide.TeacherId", "Teacher ID cannot be empty, a Guide must belong to a Teacher.");
        }

        if (!string.IsNullOrEmpty(title) && title.Length > MAX_TITLE_LENGTH)
        {
            // TODO I Have this twice, see ChangeTitle(). Refactor.
            result.AddError("Guide.Title", "Title cannot exceed 50 characters");
        }

        return result;
    }

    private Guide() // for json/db
    {
    }

    private Guide(Guid guideId, string title, CategoryId categoryId, string teacherId)
    {
        Id = guideId;
        Title = title;
        CategoryId = categoryId;
        TeacherId = teacherId;
        IsPublished = false;
        IsDisplayingStepNums = false;
        Description = "";
        Slides = new List<Slide>();
    }

    public void Publish()
    {
        IsPublished = true;
    }

    public void UnPublish()
    {
        IsPublished = false;
    }

    public void DisplayStepNums()
    {
        IsDisplayingStepNums = true;
    }

    public void HideStepNums()
    {
        IsDisplayingStepNums = false;
    }

    public Result ChangeDescription(string desc)
    {
        if (string.IsNullOrEmpty(desc))
        {
            desc = "";
        }

        if (desc.Length > 100)
        {
            return Result.Failure("Guide.Description", "Description must be less than 100 characters.");
        }

        Description = desc;

        return Result.Success();
    }

    public Result ChangeTitle(string newTitle)
    {
        if (!string.IsNullOrEmpty(newTitle) && newTitle.Length > MAX_TITLE_LENGTH)
        {
            return Result.Failure("Guide.Title", "Title cannot exceed 50 characters");
        }

        Title = newTitle;
        return Result.Success();
    }

    public void ChangeCategoryTo(Category category)
    {
        CategoryId = category.Id;
    }

    public void AddSlide(Guid slideId, int slideIndex, Guid commandSlideContentId)
    {
        // TODO need a unit test for this
        Slide slide = Slide.Create(slideId, slideIndex, commandSlideContentId);
        Slides = Slides.OrderBy(step => step.StepIndex).ToList();
        Slides.Insert(slideIndex, slide);
        for (int i = slideIndex+1; i < Slides.Count; i++)
        {
            Slides[i].PushStepDown();
        }
    }

    public Result ChangeSlideTitle(Guid slideId, string title)
    {
        Slide? slide = Slides.SingleOrDefault(step => step.Id.Equals(slideId));
        if (slide == null)
        {
            return Result.Failure("Guide.Slide.Id", $"Could not find specific slide with ID {slideId}");
        }

        return slide.ChangeTitle(title);
    }
}