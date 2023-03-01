using Domain.OperationResult;

namespace Domain.Entities;

public class Guide
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsDisplayingStepNums { get; private set; }

    public ICollection<SlideDetails> Slides { get; private set; } = new List<SlideDetails>();

    public Guid CategoryId { get; private set; }

    public string TeacherId { get; private set; }
    public string Description { get; private set; }

    public static Result<Guide> Create(Guid guideId, string title, Guid categoryId, string teacherId)
    {
        Result validationResult = Validate(guideId, title, categoryId, teacherId);
        if (validationResult.HasErrors)
        {
            return Result.Failure<Guide>(validationResult.Errors);
        }

        Guide guide = new (guideId, title, categoryId, teacherId);
        return Result.Success(guide);
    }

    private static Result Validate(Guid guideId, string title, Guid categoryId, string teacherId)
    {
        Result result = new ();
        if (guideId == null)
        {
            result.AddError("Guide.Id", "Guide ID cannot be empty.");
        }

        if (categoryId == null)
        {
            result.AddError("Guide.CategoryId", "Category ID cannot be empty, a Guide must be associated with a Category.");
        }

        if (string.IsNullOrEmpty(teacherId))
        {
            result.AddError("Guide.TeacherId", "Teacher ID cannot be empty, a Guide must belong to a Teacher.");
        }

        return result;
    }

    private Guide() // for json/db
    {
    }

    private Guide(Guid guideId, string title, Guid categoryId, string teacherId)
    {
        Id = guideId;
        Title = title;
        CategoryId = categoryId;
        TeacherId = teacherId;
        IsPublished = false;
        IsDisplayingStepNums = false;
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

    public void AddSlide(SlideDetails s, int index)
    {
        Slides.Add(s);
    }

    public void ChangeDescription(string desc)
    {
        Description = desc;
    }
}