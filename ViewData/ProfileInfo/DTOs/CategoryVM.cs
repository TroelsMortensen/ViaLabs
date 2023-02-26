namespace ViewData.ProfileInfo.DTOs;

public class CategoryVM
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string BackgroundColor { get; set; }

    public CategoryVM(Guid id, string title, string backgroundColor)
    {
        Id = id;
        Title = title;
        BackgroundColor = backgroundColor;
    }
}