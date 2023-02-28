using Dispatcher.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using ViewData;

namespace Dispatcher.Query;

/**
 * Inspiration found here https://www.youtube.com/watch?v=4e83trumwcM
 * and here https://medium.com/dotnet-hub/use-mediatr-in-asp-net-or-asp-net-core-cqrs-and-mediator-in-dotnet-how-to-use-mediatr-cqrs-aspnetcore-5076e2f2880c
 */
public class QueryDispatcherWithServiceProvider : IQueryDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public QueryDispatcherWithServiceProvider(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    /* This one is annoying to work with, because type arguments must be provided with ...Query<TeacherQuery, TeacherDto>(...) and I shouldn't have to do that.
     public Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : struct
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

    public Task<TResult> QueryAsync<TResult>(IQuery<TResult> q)
    {
        
        Type queryHandlerInterfaceType = typeof(IQueryHandler<,>);

        Type queryInterfaceWithTypes = queryHandlerInterfaceType.MakeGenericType(q.GetType(), typeof(TResult));
        var queryHandler =
            serviceProvider.GetRequiredService(queryInterfaceWithTypes);// as IQueryHandler<IQuery<TResult>, TResult>;

        if (queryHandler == null)
        {
            throw new CommandDispatcherException($"Unable to find instance of {queryInterfaceWithTypes}");
        }

        // TODO not efficient using reflection, but I got annoyed and have left it as is, for now. Will totally come back some day.
        return (Task<TResult>)queryHandler.GetType().GetMethod(nameof(Query))!.Invoke(queryHandler, new []{q}); 
    }

    // private Task<TResult> Query1<TQuery, TResult>(IQuery<TResult> query, TQuery type) where TQuery : IQuery<TResult>
    // {
    //     Type handlerInterfaceType = typeof(IQueryHandler<TQuery, TResult>);
    //
    //     Type queryInterfaceWithTypes = handlerInterfaceType.MakeGenericType(query.GetType(), typeof(TResult));
    //     IQueryHandler<TQuery,TResult>? queryHandler = serviceProvider.GetService(queryInterfaceWithTypes) as IQueryHandler<TQuery, TResult>;
    //
    //     if (queryHandler == null)
    //     {
    //         throw new CommandDispatcherException($"Unable to find instance of {queryInterfaceWithTypes}");
    //     }
    //     
    //     return queryHandler.Query(type);
    // }
}