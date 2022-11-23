using Application.Features.CategoryOverview;
using Application.Features.DisplayProfileInfo;
using Application.Features.DisplayProfileInfo.DataProvider;
using Application.Features.ProfileDataLogic.ProviderContracts;
using Application.RepositoryContracts;
using JsonData.Context;
using JsonData.JsonSerializationUtils;
using JsonData.ProviderImpls;
using JsonData.ProviderImpls.CategoryOverview;
using JsonData.ProviderImpls.ProfileInfoProviderImpls;
using JsonData.ProviderImpls.ProfileProviderImpls;
using JsonData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JsonData;

public static class JsonDataServiceExtensions
{
    public static void AddJsonDataAccess(this IServiceCollection services)
    {
        AddDataAccess(services);
        AddRepositories(services);
        AddProviders(services);
        
    }

    private static void AddProviders(IServiceCollection services)
    {
        services.AddScoped<IProfileDataProvider, JsonProfileDataProvider>();
        services.AddScoped<ICategoryOverviewDataProvider, JsonCategoryOverviewDataProvider>();
        services.AddScoped<IJsonHelper, SystemNetJsonSerializerHelper>();
        // services.AddScoped<ICategoryProvider, JsonCategoryProvider>();
        // services.AddScoped<IProfileDataProvider, JsonProfileDataProvider>();
        // services.AddScoped<IGuideProvider, JsonGuideProvider>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ITeacherRepo, TeacherJsonRepo>();
        services.AddScoped<ICategoryRepo, CategoryJsonRepo>();
        services.AddScoped<IGuideRepo, GuideJsonRepo>();
        services.AddScoped<IExternalResourceRepo, ExternalResourceJsonRepo>();
        services.AddScoped<IRepoManager, JsonRepoManagerImpl>();
    }

    private static void AddDataAccess(IServiceCollection services)
    {
        services.AddScoped<JsonDataContext>();
    }
}