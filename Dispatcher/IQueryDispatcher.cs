namespace Dispatcher;

public interface IQueryDispatcher
{
    Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : struct;
}