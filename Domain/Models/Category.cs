using System.Text.Json;
using Domain.Exceptions;

namespace Domain.Models;

public class Category
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }

    public ICollection<Guide> Guides { get; private set; }
    public ICollection<ExternalResource> ExternalResources { get; private set; }
    public string BackgroundColor { get; private set; }

    public Category(string title, string backgroundColor)
    {
        ValidateData(title, backgroundColor);
        Title = title;
        BackgroundColor = backgroundColor;
    }

    private void ValidateData(string title, string backgroundColor)
    {
        DataValidationException exception = new();

        if (string.IsNullOrEmpty(title))
        {
            exception.AddError("Title cannot be empty");
        }

        if (title.Length < 3)
        {
            exception.AddError("Title must be 3 or more characters");
        }

        if (title.Length > 25)
        {
            exception.AddError("Title must be less than 25 characters");
        }

        exception.ThrowIfErrors();
    }

    public void AddGuide(Guide guide)
    {
        Guides.Add(guide);
    }

    public void AddExternalResource(ExternalResource er)
    {
        ExternalResources.Add(er);
    }

    public void Update(string newTitle, string newBackgroundColor)
    {
        ValidateData(newTitle, newBackgroundColor);
        Title = newTitle;
        BackgroundColor = newBackgroundColor;
    }
}