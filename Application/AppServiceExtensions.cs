using Application.HandlerContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
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
        services.AddScoped<ICommandHandler<CreateCategoryCommand>, CategoryCreateHandler>();
        services.AddScoped<ICommandHandler<UpdateCategoryCommand>, CategoryUpdateHandler>();
        services.AddScoped<ICommandHandler<DeleteCategoryCommand>, CategoryDeleteHandler>();
    }
}