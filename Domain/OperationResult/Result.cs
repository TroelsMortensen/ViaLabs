using System.Runtime.CompilerServices;
using Domain.Aggregates;
using Domain.Values;

namespace Domain.OperationResult;

public class Result
{
    private readonly List<Error> errors = new();

    public static Result Success()
    {
        return new Result();
    }
    
    public static Result<TV> Success<TV>(TV value)
    {
        return new Result<TV>(value);
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
    public bool IsFailure => Errors.Any();
    public bool IsSuccess => !IsFailure;

    // convenience method, which should probably not actually be used. Errors display format should be defined in UI.
    public string GetCombinedErrorMessage() 
    {
        return string.Join(".\n", Errors.Select(error => error.Message));
    }

    public Result ThenValidate(bool expShouldBeTrue, string attribute, string errorMessage)
    {
        if (!expShouldBeTrue)
        {
            errors.Add(new Error(attribute, errorMessage));
        }

        return this;
    }

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
    
    public static Result<TV> Failure<TV>(IEnumerable<Error> enumerable)
    {
        return new Result<TV>(enumerable);
    }

    public static Result Failure(string attribute, string message)
    {
        Result result = new Result();
        result.AddError(attribute, message);
        return result;
    }

    public static Result Validation()
    {
        return new Result();
    }

    public Result Require(Func<bool> func, string attr, string error)
    {
        if (!func())
        {
            AddError(attr, error);
        }

        return this;
    }

    public  Result<T> IfSuccessElse<T>(Func<Result, Result<T>> success,Func<Result, Result<T>> failure )
    {
        return IsSuccess ? success(this) : failure(this);
    }


    public async Task<Result<Category>> Then<T>(Func<Task<Result<Category>>> func)
    {
        return await func();
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

    public static implicit operator Result<T>(T t) => new Result<T>(t);

    public static Result<T> FromResult(Result r) => new Result<T>(r.Errors);

    private Result()
    {
    }

    public Result(string errorCode, string errorMessage)
    {
        AddError(errorCode, errorMessage);
    }

    public Result(Result fromResult)
    {
        AddErrors(fromResult.Errors);
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
        get => IsFailure ? throw new NoValueWhenErrorsException() : this.value;
        set => this.value = value;
    }

}

public record struct Error(string Attribute, string Message);