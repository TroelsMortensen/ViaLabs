namespace Domain.NotificationReturn;

public class Result<T>
{
    public IEnumerable<string> Errors => errors.AsReadOnly();
    public bool HasErrors => Errors.Any();
    public T Value { get; set; } = default!;

    private readonly List<string> errors = new List<string>();

    public void AddError(string msg)
    {
        errors.Add(msg);
    }
}