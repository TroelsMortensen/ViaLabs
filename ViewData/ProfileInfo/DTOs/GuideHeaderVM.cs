namespace ViewData.ProfileInfo.DTOs;

public class GuideHeaderVM
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public GuideHeaderVM(Guid id, string title)
    {
        Id = id;
        Title = title;
    }
}