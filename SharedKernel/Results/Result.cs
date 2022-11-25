namespace SharedKernel.Results;

public class Result
{
    private readonly List<Error> errors = new();

    public Result()
    {
    }

    public Result(IEnumerable<Error> enumerable)
    {
        AddErrors(enumerable);
    }

    public Result(string attribute, string errorMessage)
    {
        AddError(attribute, errorMessage);
    }

    public void AddError(string attribute, string msg) => errors.Add(new Error(attribute, msg));
    public void AddErrors(IEnumerable<Error> errorsToAdd) => this.errors.AddRange(errorsToAdd);
    public IEnumerable<Error> Errors => errors.AsReadOnly();
    public bool HasErrors => Errors.Any();

    public string GetCombinedErrorMessage() // convenience method, which should probably not actually be used. Errors display format should be defined in UI.
    {
        return string.Join(".\n", Errors.Select(error => error.Message));
    }
}

public class Result<T> : Result
{
    private T value = default!;

    public Result()
    {
    }

    public Result(IEnumerable<Error> enumerable) : base(enumerable)
    {
    }

    public Result(T value)
    {
        this.value = value;
    }

    public Result(string attribute, string errorMessage) : base(attribute, errorMessage)
    {
    }

    public T Value
    {
        get => HasErrors ? throw new NoValueWhenErrorsException() : this.value;
        set => this.value = value;
    }
}

public record struct Error(string Attribute, string Message);