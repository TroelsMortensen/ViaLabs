using Application.HandlerContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
using Application.UseCases.GuideUseCases.GuideChangeCategory;
using Application.UseCases.GuideUseCases.GuideChangeTitle;
using Application.UseCases.GuideUseCases.GuideCreate;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayerServices(this IServiceCollection services)
    {
        AddCategoryHandlers(services);
        AddGuideHandlers(services);
        // AddServicesForCategoryOverview(services);
        // services.AddScoped<ITeacherLogic, TeacherLogic>();
        // services.AddScoped<ICategoryLogic, CategoryLogic>();
        // services.AddScoped<IGuideLogic, GuideLogic>();
        // services.AddScoped<IExternalResourceLogic, ExternalResourceLogic>();
    }

    private static void AddGuideHandlers(IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateGuideCommand>, GuideCreateHandler>();
        services.AddScoped<ICommandHandler<ChangeGuideTitleCommand>, ChangeGuideTitleHandler>();
        services.AddScoped<ICommandHandler<ChangeGuideCategoryCommand>, ChangeGuideCategoryCommandHandler>();
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