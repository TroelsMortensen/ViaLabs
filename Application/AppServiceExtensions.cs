﻿using Application.CommandUseCases.CategoryHandlers.CategoryCreate;
using Application.CommandUseCases.CategoryHandlers.CategoryDelete;
using Application.CommandUseCases.CategoryHandlers.CategoryUpdate;
using Application.HandlerContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayerServices(this IServiceCollection services)
    {
        AddCategoryHandlers(services);
        // AddServicesForCategoryOverview(services);
        // services.AddScoped<ITeacherLogic, TeacherLogic>();
        // services.AddScoped<ICategoryLogic, CategoryLogic>();
        // services.AddScoped<IGuideLogic, GuideLogic>();
        // services.AddScoped<IExternalResourceLogic, ExternalResourceLogic>();
    }



    // private static void AddServicesForCategoryOverview(IServiceCollection services)
    // {
    //     
    // }

    private static void AddCategoryHandlers(IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateCategoryCommand, Guid>, CategoryCreateHandler>();
        services.AddScoped<ICommandHandler<UpdateCategoryCommand>, CategoryUpdateHandler>();
        services.AddScoped<ICommandHandler<DeleteCategoryCommand>, CategoryDeleteHandler>();
    }
}