using Application.Features.DisplayProfileInfo.DTOs;

namespace Application.Features.DisplayProfileInfo.DataProvider;

public interface IProfileDataProvider
{
    Task<TeacherHeaderDto> GetTeacherAsync(string userName);
}