using Application.ServiceContracts;
using Application.ServiceImpls;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGuideService, GuideService>();
        services.AddScoped<IExternalResourceService, ExternalResourceService>();
    }
}