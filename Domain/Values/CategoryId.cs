namespace Domain.Values;

public record CategoryId()
{
    public Guid Value { get; private set; }

    private CategoryId(Guid id) : this()
    {
        Value = id;
    }

    public static CategoryId Create()
    {
        return new CategoryId(Guid.NewGuid());
    }

    public static CategoryId FromString(string idAsString)
    {
        return new CategoryId(Guid.Parse(idAsString));
    }

    public static CategoryId FromGuid(Guid idAsGuid)
    {
        return new CategoryId(idAsGuid);
    }
}