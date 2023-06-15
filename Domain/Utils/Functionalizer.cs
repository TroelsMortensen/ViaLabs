using Domain.OperationResult;

namespace Domain.Utils;

public static class Functionalizer
{
    // Task
    public static async Task<R> Map<T, R>(this Task<T> task, Func<T, R> f) => f(await task);

    public static async Task<Result<T>> Apply<T>(this Task<T> task, Func<T, Result<T>> f) => f(await task);

    public static async  Task<Result<T>> IfSuccessElse<T>(this Task<Result<T>> task, Func<Result<T>, Result<T>> success,Func<Result<T>, Result<T>> failure )
    {
        return (await task).IsSuccess ? success(await task) : failure(await task);
    }    
    public static async  Task<Result<T>> IfSuccess<T>(this Task<Result<T>> task, Func<Result<T>, Result<T>> success )
    {
        return (await task).IsSuccess ? success(await task) : (await task);
    }
}