using Application.Features.DisplayProfileInfo;
using Application.Features.DisplayProfileInfo.DataProvider;
using Application.Features.DisplayProfileInfo.DTOs;
using Domain.Exceptions;
using Domain.Models;
using JsonData.Context;

namespace JsonData.ProviderImpls.ProfileInfoProviderImpls;

public class JsonProfileDataProvider : IProfileDataProvider
{
    private readonly JsonDataContext context;

    public JsonProfileDataProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<TeacherHeaderDto> GetTeacherAsync(string userName)
    {
        Teacher? teacher = context.Teachers.SingleOrDefault(t => t.Name.Equals(userName));

        if (teacher is null)
        {
            throw new NotFoundException($"Did not find teacher by name {userName}");
        }

        TeacherHeaderDto result = new TeacherHeaderDto(teacher.Name);
        return Task.FromResult(result);
    }
}