using Domain.Models;

namespace Application.ProviderContracts;

public interface ITeacherProvider
{
    Task<Teacher> GetTeacherAsync(string userName);
}