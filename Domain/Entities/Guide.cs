using Domain.OperationResult;

namespace Domain.Entities;

public class Guide
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsDisplayingStepNums { get; private set; }

    public ICollection<Slide> Slides { get; private set; } = new List<Slide>();

    public Guid CategoryId { get; private set; }
    
    public Guid TeacherId { get; private set; }

    public static Result<Guide> Create(Guid guideId, string title, Guid categoryId, Guid teacherId)
    {
        Result validationResult = Validate(guideId, title, categoryId, teacherId);
        if (validationResult.HasErrors)
        {
            return Result.Failure<Guide>(validationResult.Errors);
        }

        Guide guide = new Guide(guideId, title, categoryId, teacherId);
        return Result.Success(guide);
    }

    private static Result Validate(Guid guideId, string title, Guid categoryId, Guid teacherId)
    {
        // TODO actually do some validation here
        return Result.Success();
    }
    private Guide() // for json/db
    {
        
    }

    private Guide(Guid guideId, string title, Guid categoryId, Guid teacherId)
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
    public void AddSlide(Slide s, int index)
    {
        Slides.Add(s);
    }
}