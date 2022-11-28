using Application.Features.DisplayProfileInfo;
using Application.Features.DisplayProfileInfo.DataProvider;
using Application.Features.DisplayProfileInfo.DTOs;
using Domain.Exceptions;
using Domain.Models;
using JsonData.Context;
using SharedKernel.Results;

namespace JsonData.ProviderImpls.ProfileInfoProviderImpls;

public class JsonProfileDataProvider : IProfileDataProvider
{
    private readonly CollectionsDataContext context;

    public JsonProfileDataProvider(CollectionsDataContext context)
    {
        this.context = context;
    }

    public Task<Result<TeacherHeaderDto>> GetTeacherAsync(string userName)
    {
        Result<TeacherHeaderDto> opResult = new();
        Teacher? teacher = context.Teachers.SingleOrDefault(t => t.Name.Equals(userName));

        if (teacher is null)
        {
            opResult.AddError("User Name", ($"Did not find teacher by name {userName}"));
            return Task.FromResult(opResult);
        }

        TeacherHeaderDto result = new (teacher.Name);
        opResult.Value = result;
        
        return Task.FromResult(opResult);
    }
}