namespace Application.DTOs.CategoryDTOs;

public class CategoryCreationDto
{
    public string Title { get; set; }
    public string OwnerId { get; set; }

    public string BackgroundColor { get; set; }

    public CategoryCreationDto(string title, string ownerId, string backgroundColor)
    {
        Title = title;
        OwnerId = ownerId;
        BackgroundColor = backgroundColor;
    }
}