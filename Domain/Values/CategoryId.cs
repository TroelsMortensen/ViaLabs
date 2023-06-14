namespace Domain.Values;

public record CategoryId()
{
    private CategoryId(Guid id) : this()
    {
        Value = id;
    }

    public Guid Value { get; }
    public static CategoryId Create()
    {
        return new CategoryId(Guid.NewGuid());
    }
}