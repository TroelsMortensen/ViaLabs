using Application.Features.DisplayProfileInfo.DTOs;
using SharedKernel.Results;

namespace Application.Features.DisplayProfileInfo.DataProvider;

public interface IProfileDataProvider
{
    Task<Result<TeacherHeaderDto>> GetTeacherAsync(string userName);
}