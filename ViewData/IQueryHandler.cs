
namespace ViewData;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Query(TQuery query);
}