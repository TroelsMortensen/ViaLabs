using Application.EntryContracts;
using Application.HomeImpls;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGuideService, GuideService>();
    }
}