namespace Domain.OperationResult;

public class Result
{
    private readonly List<Error> errors = new();

    public static Result Success()
    {
        return new Result();
    }
    
    public Result()
    {
    }

    public Result(IEnumerable<Error> enumerable)
    {
        AddErrors(enumerable);
    }

    public void AddError(string attribute, string msg) => errors.Add(new Error(attribute, msg));
    public void AddErrors(IEnumerable<Error> errorsToAdd) => this.errors.AddRange(errorsToAdd);
    public IEnumerable<Error> Errors => errors.AsReadOnly();
    public bool HasErrors => Errors.Any();

    public string
        GetCombinedErrorMessage() // convenience method, which should probably not actually be used. Errors display format should be defined in UI.
    {
        return string.Join(".\n", Errors.Select(error => error.Message));
    }

    public static Result Validation()
    {
        return new Result();
    }


    // Didn't like this

    // Attempt at Fluent result.
    // public Result IfSuccessThen(Func<bool> exp, string attribute, string msg)
    // {
    //     if (HasErrors)
    //     {
    //         return this;
    //     }
    //
    //     bool validationResult = exp();
    //     if (!validationResult)
    //     {
    //         errors.Add(new Error(attribute, msg));
    //     }
    //
    //     return this;
    // }

    public Result ThenValidate(bool expShouldBeTrue, string attribute, string errorMessage)
    {
        if (!expShouldBeTrue)
        {
            errors.Add(new Error(attribute, errorMessage));
        }

        return this;
    }

    // Don't need this yet
    // public Result IfFailure()
    // {
    // }
    public void AddResults(params Result[] results)
    {
        foreach (Result result in results)
        {
            AddErrors(result.errors);
        }
    }


    public static Result Failure(IEnumerable<Error> enumerable)
    {
        Result result = new(enumerable);
        return result;
    }
}

public class Result<T> : Result
{
    private T value = default!;

    public Result(IEnumerable<Error> errors) : base(errors)
    {
    }
    
    public Result(T tvalue)
    {
        value = tvalue;
    }

    private Result()
    {
    }

    public Result(string errorCode, string errorMessage)
    {
        AddError(errorCode, errorMessage);
    }


    // public Result()
    // {
    // }
    //
    // public Result(IEnumerable<Error> enumerable) : base(enumerable)
    // {
    // }
    //
    // public Result(T value)
    // {
    //     this.value = value;
    // }
    //
    // public Result(string attribute, string errorMessage) : base(attribute, errorMessage)
    // {
    // }

    public T Value
    {
        get => HasErrors ? throw new NoValueWhenErrorsException() : this.value;
        set => this.value = value;
    }
}

public record struct Error(string Attribute, string Message);