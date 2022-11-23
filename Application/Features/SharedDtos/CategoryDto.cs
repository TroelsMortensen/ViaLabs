namespace Application.Features.SharedDtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string BackgroundColor { get; set; }

    public CategoryDto(Guid id, string title, string backgroundColor)
    {
        Id = id;
        Title = title;
        BackgroundColor = backgroundColor;
    }
}