using Domain.Models;

namespace Application.Features.ProfileDataLogic.ProviderContracts;

public interface ITeacherProvider
{
    Task<Teacher> GetTeacherAsync(string userName);
}