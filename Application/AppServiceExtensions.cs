using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        AddServicesForDisplayProfileInfo(services);
        AddServicesForCreateCategory(services);
        AddServicesForCategoryOverview(services);
        // services.AddScoped<ITeacherLogic, TeacherLogic>();
        // services.AddScoped<ICategoryLogic, CategoryLogic>();
        // services.AddScoped<IGuideLogic, GuideLogic>();
        // services.AddScoped<IExternalResourceLogic, ExternalResourceLogic>();
    }

    private static void AddServicesForCategoryOverview(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    private static void AddServicesForCreateCategory(IServiceCollection services)
    {
        throw new NotImplementedException();
    }

    private static void AddServicesForDisplayProfileInfo(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}