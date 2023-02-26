namespace ViewData.ProfileInfo.DTOs;

public class ExternalResourceDisplayVM
{
    public ExternalResourceDisplayVM(Guid id, string title, string url, string? description)
    {
        Id = id;
        Title = title;
        Url = url;
        Description = description;
    }

    public Guid Id { get; set; }
    // public string OwnerId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string? Description { get; set; }
    // public Guid? CategoryId { get; set; }
}