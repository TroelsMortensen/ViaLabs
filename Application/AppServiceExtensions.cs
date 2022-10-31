using Application.Features;
using Application.Features.ProfileDataLogic;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.Features.ProfileDataLogic.LogicImpls;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherLogic, TeacherLogic>();
        services.AddScoped<ICategoryLogic, CategoryLogic>();
        services.AddScoped<IGuideLogic, GuideLogic>();
        services.AddScoped<IExternalResourceLogic, ExternalResourceLogic>();
    }
}