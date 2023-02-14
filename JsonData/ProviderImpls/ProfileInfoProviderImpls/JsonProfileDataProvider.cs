using Application.Features.DisplayProfileInfo;
using Application.Features.DisplayProfileInfo.DataProvider;
using Application.Features.DisplayProfileInfo.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using JsonData.Context;
using SharedKernel.OperationResult;

namespace JsonData.ProviderImpls.ProfileInfoProviderImpls;

internal class JsonProfileDataProvider : IProfileDataProvider
{
    private readonly JsonDataContext context;

    internal JsonProfileDataProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Result<TeacherHeaderDto>> GetTeacherAsync(string userName)
    {
        Teacher? teacher = context.Teachers.SingleOrDefault(t => t.Name.Equals(userName));

        if (teacher is null)
        {
            var errorResult = new Result<TeacherHeaderDto>("User Name", $"Did not find teacher by name {userName}");
            return Task.FromResult(errorResult);
        }

        TeacherHeaderDto resultDto = new(teacher.Name);

        Result<TeacherHeaderDto> result = new Result<TeacherHeaderDto>(resultDto);
        
        return Task.FromResult(result);
    }
}