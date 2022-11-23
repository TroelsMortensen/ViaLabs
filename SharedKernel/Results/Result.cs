namespace SharedKernel.Results;

public class Result<T>
{
    private readonly List<Error> errors = new List<Error>();
    private T? value;

    public IEnumerable<Error> Errors => errors.AsReadOnly();
    public bool HasErrors => Errors.Any();

    public T? Value
    {
        get => HasErrors ? default(T) : value;
        set => this.value = value;
    }

    public void AddError(string attribute, string msg)
    {
        errors.Add(new Error(attribute, msg));
    }

    public void AddErrors(IEnumerable<Error> errorsToAdd)
    {
        this.errors.AddRange(errorsToAdd);
    }

    public record struct Error(string Attribute, string Message);
}