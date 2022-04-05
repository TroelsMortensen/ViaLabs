using Application.ProviderContracts;
using Application.ProviderContracts;
using Application.RepositoryContracts;
using JsonData.DataAccess;
using JsonData.ProviderImpls;
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
        services.AddScoped<ICategoryProvider, JsonCategoryProvider>();
        services.AddScoped<ITeacherProvider, JsonTeacherProvider>();
        services.AddScoped<IGuideProvider, JsonGuideProvider>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ITeacherRepo, TeacherRepo>();
        services.AddScoped<ICategoryRepo, CategoryRepo>();
        services.AddScoped<IGuideRepo, GuideRepo>();
        services.AddScoped<IRepoUOW, JsonRepoUowImpl>();
    }

    private static void AddDataAccess(IServiceCollection services)
    {
        services.AddScoped<JsonDataContext>();
        services.AddScoped<IDbContext, JsonDataContext>();
    }
}