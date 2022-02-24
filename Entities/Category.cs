namespace Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string OwnerId { get; set; }
    public string BackgroundColor { get; set; }

    // public ICollection<Guide> Guides { get; set; }
    // public ICollection<VideoLink> Links { get; set; }
}