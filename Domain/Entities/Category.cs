using SharedKernel.Results;

namespace Domain.Entities;

public class Category
{
    // private fields to be able to update.
    private string title = null!;
    private string backgroundColor = null!;
    public Guid Id { get; init; }

    public string Title
    {
        get => title;
        init => title = value;
    }

    public string BackgroundColor
    {
        get => backgroundColor;
        init => backgroundColor = value;
    }

    public ICollection<Guide> Guides { get; init; }
    public ICollection<ExternalResource> ExternalResources { get; init; }

    public static Result<Category> Create(string title, string backgroundColor)
    {
        Result validationResult = ValidateData(title, backgroundColor);

        if (validationResult.HasErrors)
            return new Result<Category>(validationResult.Errors);

        Result<Category> createdResult =
            new Result<Category>(
                new Category(Guid.NewGuid(), title, backgroundColor, new List<Guide>(), new List<ExternalResource>()));
        
        return createdResult;
    }

    private Category(Guid id, string title, string backgroundColor, ICollection<Guide> guides,
        ICollection<ExternalResource> externalResources)
    {
        Id = id;
        Title = title;
        Guides = guides;
        ExternalResources = externalResources;
        BackgroundColor = backgroundColor;
    }

    public void AddGuide(Guide guide)
    {
        // TODO Check if guide exists in collection?
        Guides.Add(guide);
    }

    public void AddExternalResource(ExternalResource er)
    {
        // TODO Check if Ex Res exists in collection
        ExternalResources.Add(er);
    }

    private Category(){}

    private static Result ValidateData(string title, string backgroundColor)
    {
        Result result = new();

        if (string.IsNullOrEmpty(title))
        {
            result.AddError("Category.Title", "Title cannot be empty");
        }

        if (title.Length < 3)
        {
            result.AddError("Category.Title", "Title must be 3 or more characters");
        }

        if (title.Length > 25)
        {
            result.AddError("Category.Title", "Title must be less than 25 characters");
        }

        return result;
    }

    public Result Update(string newTitle, string newBackgroundColor)
    {
        Result validationResult = ValidateData(newTitle, newBackgroundColor);
        if (validationResult.HasErrors)
            return validationResult;
        
        title = newTitle;
        backgroundColor = newBackgroundColor;
        return new();
    }
}