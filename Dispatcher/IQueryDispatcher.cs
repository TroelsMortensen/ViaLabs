using ViewData;

namespace Dispatcher;

public interface IQueryDispatcher
{
    Task<TResult> Query<TResult>(IQuery<TResult> query);
}