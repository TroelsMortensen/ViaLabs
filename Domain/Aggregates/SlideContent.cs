namespace Domain.Aggregates;

public class SlideContent
{
    public Guid Id { get; private set; }

    public string MarkdownContent { get; private set; }

    private SlideContent() // EFC / JSON
    {
    }
    
    private SlideContent(Guid id)
    {
        Id = id;
    }

    public static SlideContent Create(Guid id)
    {
        return new SlideContent(id);
    }

    public void UpdateContent(string content)
    {
        MarkdownContent = content;
    }
}