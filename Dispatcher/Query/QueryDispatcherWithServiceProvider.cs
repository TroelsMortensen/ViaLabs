﻿using Dispatcher.Exceptions;
using ViewData;

namespace Dispatcher.Query;

public class QueryDispatcherWithServiceProvider : IQueryDispatcher
{
    
    private readonly IServiceProvider serviceProvider;

    public QueryDispatcherWithServiceProvider(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

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
    }
}