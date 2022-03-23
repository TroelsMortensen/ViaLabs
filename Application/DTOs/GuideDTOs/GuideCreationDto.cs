namespace Application.DTOs.GuideDTOs;

public class GuideCreationDto
{
    public string Title { get; set; }
    public string OwnerId { get; set; }
    public Guid? CategoryId { get; set; }
}