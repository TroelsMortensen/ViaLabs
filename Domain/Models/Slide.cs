namespace Domain.Models;

public class Slide
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }

    public Slide(string title)
    {
        Title = title;
        throw new Exception("Missing domain validation here");

    }
}