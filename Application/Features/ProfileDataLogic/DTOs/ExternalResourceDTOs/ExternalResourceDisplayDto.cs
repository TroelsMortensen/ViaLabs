namespace Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;

public class ExternalResourceDisplayDto
{
    public Guid Id { get; set; }
    // public string OwnerId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string? Description { get; set; }
    // public Guid? CategoryId { get; set; }
}