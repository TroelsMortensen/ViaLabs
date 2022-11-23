using SharedKernel.Results;

namespace Domain.Models;

public class Category
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }

    public ICollection<Guide> Guides { get; private set; } = new List<Guide>();
    public ICollection<ExternalResource> ExternalResources { get; private set; } = new List<ExternalResource>();
    public string BackgroundColor { get; private set; }

    public static Result<Category> Create(string title, string backgroundColor)
    {
        Result<Category> result = ValidateData(title, backgroundColor);
        
        if (result.HasErrors)
            return result;
        
        result.Value = new(title, backgroundColor);
        return result;
    }

    private Category(string title, string backgroundColor)
    {
        Title = title;
        BackgroundColor = backgroundColor;
    }

    private static Result<Category> ValidateData(string title, string backgroundColor)
    {
        Result<Category> result = new();
        
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

    public Result Update(string newTitle, string newBackgroundColor)
    {
        ValidateData(newTitle, newBackgroundColor);
        Title = newTitle;
        BackgroundColor = newBackgroundColor;
        return new();
    }
}