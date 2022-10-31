using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface IExternalResourceLogic
{
    Task<ExternalResourceDisplayDto> CreateAsync(ExtRecourseCreationDto dto);
    Task UpdateAsync(ExternalResourceDisplayDto resource);
    Task DeleteAsync(ExternalResourceDisplayDto dto);
}