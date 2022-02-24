﻿using Application.EntryContracts;
using Application.HomeImpls;
using Application.Profile;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherHome, TeacherHome>();
        services.AddScoped<ICategoryHome, CategoryHome>();
    }
}