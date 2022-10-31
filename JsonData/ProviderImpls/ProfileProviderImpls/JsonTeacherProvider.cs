using Application.Features.ProfileDataLogic.ProviderContracts;
using Domain.Models;
using JsonData.Context;

namespace JsonData.ProviderImpls.ProfileProviderImpls;

public class JsonTeacherProvider : ITeacherProvider
{
    private readonly JsonDataContext context;

    public JsonTeacherProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Teacher> GetTeacherAsync(string userName)
    {
        Teacher? teacher = context.Teachers.FirstOrDefault(t => t.Name.Equals(userName));

        if (teacher is null)
        {
            throw new Exception($"Did not find teacher by name {userName}");
        }
        
        return Task.FromResult(teacher);
    }
}