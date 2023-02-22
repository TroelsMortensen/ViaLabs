using Dispatcher.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using ViewData;

namespace Dispatcher.Query;

public class QueryDispatcherWithServiceProvider : IQueryDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public QueryDispatcherWithServiceProvider(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    /*  public Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : struct
      {
          Type handlerInterfaceType = typeof(IQueryHandler<TQuery, TResult>);
  
          Type queryInterfaceWithTypes = handlerInterfaceType.MakeGenericType(query.GetType(), typeof(TResult));
          IQueryHandler<TQuery,TResult>? queryHandler = serviceProvider.GetService(queryInterfaceWithTypes) as IQueryHandler<TQuery, TResult>;
  
          if (queryHandler == null)
          {
              throw new CommandDispatcherException($"Unable to find instance of {queryInterfaceWithTypes}");
          }
          
          return queryHandler.Query(query);
      }*/

    public Task<TResult> Query<TResult>(IQuery<TResult> q)
    {
        
        Type queryHandlerInterfaceType = typeof(IQueryHandler<,>);

        Type queryInterfaceWithTypes = queryHandlerInterfaceType.MakeGenericType(q.GetType(), typeof(TResult));
        var queryHandler =
            serviceProvider.GetRequiredService(queryInterfaceWithTypes);// as IQueryHandler<IQuery<TResult>, TResult>;

        if (queryHandler == null)
        {
            throw new CommandDispatcherException($"Unable to find instance of {queryInterfaceWithTypes}");
        }

        // return queryHandler.Query(q);
        return (Task<TResult>)queryHandler.GetType().GetMethod(nameof(Query))!.Invoke(queryHandler, new [] {q}); // TODO not efficient using reflection
    }

    private Task<TResult> Query1<TQuery, TResult>(IQuery<TResult> query, TQuery type) where TQuery : IQuery<TResult>
    {
        Type handlerInterfaceType = typeof(IQueryHandler<TQuery, TResult>);

        Type queryInterfaceWithTypes = handlerInterfaceType.MakeGenericType(query.GetType(), typeof(TResult));
        IQueryHandler<TQuery,TResult>? queryHandler = serviceProvider.GetService(queryInterfaceWithTypes) as IQueryHandler<TQuery, TResult>;

        if (queryHandler == null)
        {
            throw new CommandDispatcherException($"Unable to find instance of {queryInterfaceWithTypes}");
        }
        
        return queryHandler.Query(type);
    }
}