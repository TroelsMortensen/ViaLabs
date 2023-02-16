using Domain.Exceptions;

namespace Domain.Entities;

public class ExternalResource
{
    public Guid Id { get; private set; } 
    public string Title { get; private set; }
    public string Url { get; private set; }
    public string? Description { get; private set; }
    
    public Guid Category { get; private set; }

    private ExternalResource(){}
    
    private ExternalResource(string title, string url, Guid parentCategory)
    {
        Title = title;
        Url = url;
        Id = Guid.NewGuid();
        Category = parentCategory;
        ValidateData(title, url);
        throw new Exception("Do factory method");
    }

    public void SetDescription(string desc)
    {
        ValidateDescription(desc);
        Description = desc;
    }

    public void Update(string editedTitle, string? editedDescription, string editedUrl)
    {
        ValidateData(editedTitle, editedUrl);
        ValidateDescription(editedDescription);
        Title = editedTitle;
        Description = editedDescription;
        Url = editedUrl;
    }

    private static void ValidateData(string title, string url)
    {
        DataValidationException exception = new ("Invalid data.");
        if (string.IsNullOrEmpty(title))
        {
            exception.AddError("Title cannot be empty.");
        }

        if (title.Length > 100)
        {
            exception.AddError("Title must be less than 100 characters.");
        }

        if (string.IsNullOrEmpty(url))
        {
            exception.AddError("The Url cannot be empty");
        }

        exception.ThrowIfErrors();
    }

    private static void ValidateDescription(string? desc)
    {
        if (desc is null) return;
        if (desc.Length > 250)
        {
            throw new DataValidationException("Description length must be less than 250");
        }
    }
}