using ViewData;

namespace ApplicationEntry;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
}