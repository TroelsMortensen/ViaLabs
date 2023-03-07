using Application.HandlerContracts;
using Application.UseCases.CategoryUseCases.CategoryCreate;
using Application.UseCases.CategoryUseCases.CategoryDelete;
using Application.UseCases.CategoryUseCases.CategoryUpdate;
using Application.UseCases.GuideUseCases.ChangeCategory;
using Application.UseCases.GuideUseCases.ChangeDescription;
using Application.UseCases.GuideUseCases.ChangeStepsNumberVisibility;
using Application.UseCases.GuideUseCases.ChangeTitle;
using Application.UseCases.GuideUseCases.Create;
using Application.UseCases.GuideUseCases.CreateSlide;
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
        services.AddScoped<ICommandHandler<ChangeGuideDescriptionCommand>, ChangeGuideDescriptionCommandHandler>();
        services.AddScoped<ICommandHandler<HideStepNumbersCommand>, HideGuideStepNumbersCommandHandler>();
        services.AddScoped<ICommandHandler<ShowStepNumbersCommand>, ShowGuideStepNumbersCommandHandler>();
        services.AddScoped<ICommandHandler<CreateSlideCommand>, CreateSlideCommandHandler>();
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