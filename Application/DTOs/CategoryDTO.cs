namespace Application.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string BackgroundColor { get; set; }

    public IList<GuideHeaderDto> Guides { get; set; }
}