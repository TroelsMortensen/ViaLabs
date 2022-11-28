namespace Domain.Entities;

public class Slide
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }

    public Slide(string title)
    {
        Title = title;
        throw new Exception("Missing domain validation here");
    }

}