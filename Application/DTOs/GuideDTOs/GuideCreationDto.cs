namespace Application.DTOs.GuideDTOs;

public class GuideCreationDto
{
    public string Title { get; set; }
    public string OwnerId { get; set; }
    public Guid? CategoryId { get; set; }

    public GuideCreationDto(string title, string ownerId, Guid? categoryId)
    {
        Title = title;
        OwnerId = ownerId;
        CategoryId = categoryId;
    }
}