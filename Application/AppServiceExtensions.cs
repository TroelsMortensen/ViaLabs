using Application.Features.CreateCategory;
using Application.Features.DisplayProfileInfo;
using Application.Features.DisplayProfileInfo.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayerServices(this IServiceCollection services)
    {
        AddServicesForDisplayProfileInfo(services);
        AddServicesForCreateCategory(services);
        AddServicesForCategoryOverview(services);
        // services.AddScoped<ITeacherLogic, TeacherLogic>();
        // services.AddScoped<ICategoryLogic, CategoryLogic>();
        // services.AddScoped<IGuideLogic, GuideLogic>();
        // services.AddScoped<IExternalResourceLogic, ExternalResourceLogic>();
    }

    private static void AddServicesForDisplayProfileInfo(IServiceCollection services)
    {
        services.AddScoped<IProfileDataHandler, ProfileDataHandler>();
    }

    private static void AddServicesForCategoryOverview(IServiceCollection services)
    {
        
    }

    private static void AddServicesForCreateCategory(IServiceCollection services)
    {
        services.AddScoped<ICreateCategoryHandler, CreateCategoryHandler>();
    }
}