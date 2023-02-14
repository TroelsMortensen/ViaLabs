
using Domain.OperationResult;

namespace ViewData;

public interface IQueryHandler<TQuery, TResultValue>
{
    Task<TResultValue> Query(TQuery query);
}