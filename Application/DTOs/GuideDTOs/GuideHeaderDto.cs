namespace Application.DTOs.GuideDTOs;

public class GuideHeaderDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public GuideHeaderDto(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}