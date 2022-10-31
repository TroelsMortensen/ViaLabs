using Application.ProviderContracts;
using Application.RepositoryContracts;
using Domain.Models;
using JsonData.DataAccess;

namespace JsonData.ProviderImpls;

public class JsonTeacherProvider : ITeacherProvider
{
    private readonly JsonDataContext context;

    public JsonTeacherProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<Teacher> GetTeacherAsync(string userName)
    {
        Teacher? teacher = context.ViaLabData.Teachers.FirstOrDefault(t => t.Name.Equals(userName));

        if (teacher is null)
        {
            throw new Exception($"Did not find teacher by name {userName}");
        }
        
        return Task.FromResult(teacher!);
    }
}