using Application.Repositories;
using JsonData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JsonData;

public static class JsonDataServiceExtensions
{
    public static void AddJsonDataServices(this IServiceCollection services)
    {
        services.AddScoped<JsonDataContext>();
        services.AddScoped<ITeacherRepo, TeacherRepo>();
        services.AddScoped<ICategoryRepo, CategoryRepo>();
        services.AddScoped<IGuideRepo, GuideRepo>();
    }
}