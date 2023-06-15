using Domain.OperationResult;
using Domain.Values;

namespace Domain.Aggregates;

public class Category
{
    public CategoryId Id { get; private set; }

    public string Title { get; private set; }

    public string BackgroundColor { get; private set; }

    public string Owner { get; private set; }

    public static Result<Category> Create(string title, string backgroundColor, string owningTeacher, CategoryId id)
    {
        title = title == null ? "" : title.Trim(' ');

        Result validationResult = ValidateData(title, backgroundColor);

        return validationResult.IsFailure
            ? new Result<Category>(validationResult.Errors)
            : new(
                new Category(
                    id,
                    title,
                    backgroundColor, 
                    owningTeacher)
            );
    }

    private Category(CategoryId id, string title, string backgroundColor, string owningTeacher)
    {
        Id = id;
        Title = title;
        BackgroundColor = backgroundColor;
        Owner = owningTeacher;
    }

    // public void AddGuide(Guide guide)
    // {
    //     // TODO Check if guide exists in collection?
    //     Guides.Add(guide);
    // }
    //
    // public void AddExternalResource(ExternalResource er)
    // {
    //     // TODO Check if Ex Res exists in collection
    //     ExternalResources.Add(er);
    // }

    private Category()
    {
    }

    private static Result ValidateData(string title, string backgroundColor) 
    {
        Result result = new();

        Result titleValidationResult = ValidateTitle(title);
        Result backgroundColorValidationResult = ValidateColor(backgroundColor);

        result.AddResults(titleValidationResult, backgroundColorValidationResult);

        return result;
    }

    private static Result ValidateTitle(string title)
    {
        string attr = "Category.Title";
        Result result = new();

        if (string.IsNullOrEmpty(title))
        {
            result.AddError(attr, "Title cannot be empty");
            return result;
        }

        result.ThenValidate(title.Length >= 3, attr, "Title must be 3 or more characters")
            .ThenValidate(title.Length <= 25, attr, "Title must be less than 25 characters");

        return result;
    }

    private static Result ValidateColor(string color)
    {
        string attr = "Category.BackgroundColor";
        Result result = new();

        if (string.IsNullOrEmpty(color))
        {
            result.AddError(attr, "Color cannot be empty.");
            return result;
        }

        result.ThenValidate(HasValidLength(color), attr, "Color must be on hex format: '#000000'. Length must be 4 or 7 characters.")
            .ThenValidate(StartsWithHash(color), attr, "Color must be on hex format: '#000000'. Must start with '#'.")
            .ThenValidate(IsValidColorCode(color), attr, "Color must be on hex format: '#000000'. Each character is between 0 and f.");

        return result;

        //TODO someday use regex.
    }

    private static bool IsValidColorCode(string color)
    {
        string clr = color.ToLower();
        for (int i = 1; i < color.Length; i++)
        {
            char charToCheck = clr[i];
            if (!IsValidHexDigit(charToCheck))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsValidHexDigit(char charToCheck)
    {
        return IsBetween0And9(charToCheck) || IsBetweenAndF(charToCheck);
    }

    private static bool IsBetweenAndF(char c)
    {
        return c >= 'a' && c <= 'f';
    }

    private static bool IsBetween0And9(char c)
    {
        return c >= '0' && c <= '9';
    }

    private static bool HasValidLength(string color)
    {
        return color.Length is 4 or 7;
    }

    private static bool StartsWithHash(string color)
    {
        return color[0] == '#';
    }

    public Result Update(string newTitle, string newBackgroundColor)
    {
        Result validationResult = ValidateData(newTitle, newBackgroundColor);
        if (validationResult.IsFailure)
            return validationResult;

        Title = newTitle;
        BackgroundColor = newBackgroundColor;

        return Result.Success();
    }
}