using Application.RepositoryContracts;
using JsonData.Context;
using JsonData.JsonSerializationUtils;
using JsonData.QueryImpls.ProfileViewQueries;
using JsonData.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData;

public static class JsonDataServiceExtensions
{
    public static void AddJsonDataAccess(this IServiceCollection services)
    {
        AddDataAccess(services);
        AddRepositories(services);
        AddQueryHandlers(services);
    }

    private static void AddQueryHandlers(IServiceCollection services)
    {
        AddForProfileView(services);
    }

    private static void AddForProfileView(IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<ProfileInfoOverviewQuery, ICollection<CategoryWithGuidesAndResourcesVM>>, ProfileInfoOverviewQueryHandler>();
        services.AddScoped<IQueryHandler<TeacherQuery, TeacherVM>, TeacherForProfileViewQueryHandler>();
        services.AddScoped<IQueryHandler<CategoryInfoByIdQuery, CategoryVM>, CategoryInfoByIdQueryHandler>();
        services.AddScoped<IQueryHandler<GuideHeaderQuery, GuideHeaderVM>, GuideHeaderDtoQueryHandler>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ITeacherRepo, TeacherJsonRepo>();
        services.AddScoped<ICategoryRepo, CategoryJsonRepo>();
        services.AddScoped<IGuideRepo, GuideJsonRepo>();
        services.AddScoped<IExternalResourceRepo, ExternalResourceJsonRepo>();
        services.AddScoped<IUnitOfWork, JsonUnitOfWorkImpl>();
    }

    private static void AddDataAccess(IServiceCollection services)
    {
        services.AddScoped<JsonDataContext>();
        services.AddScoped<IJsonHelper, SystemNetJsonSerializerHelper>();
    }
}