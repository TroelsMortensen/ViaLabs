using System.ComponentModel.DataAnnotations;
using Domain.Exceptions;

namespace Domain.Models;

public class ExternalResource
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Url { get; private set; }
    public string? Description { get; private set; }

    public ExternalResource(string title, string url)
    {
        Title = title;
        Url = url;
        ValidateData(title, url);
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