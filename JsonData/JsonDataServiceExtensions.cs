﻿using Application.RepositoryContracts;
using JsonData.Context;
using JsonData.JsonSerializationUtils;
using JsonData.QueryImpls.ProfileViewQueries;
using JsonData.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;
using SingleCategoryInfoQuery = ViewData.ProfileInfo.Queries.SingleCategoryInfoQuery;

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
        services.AddScoped<IQueryHandler<GetProfileInfo, ICollection<CategoryWithGuidesAndResourcesDto>>, GetCategoryOverviewByTeacher>();
        services.AddScoped<IQueryHandler<TeacherQuery, TeacherDto>, GetTeacherForProfileView>();
        services.AddScoped<IQueryHandler<SingleCategoryInfoQuery, CategoryDto>, QueryImpls.ProfileViewQueries.SingleCategoryInfoQuery>();
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