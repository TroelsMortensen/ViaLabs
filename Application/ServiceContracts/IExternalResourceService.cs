using Application.DTOs.ExternalResourceDTOs;

namespace Application.ServiceContracts;

public interface IExternalResourceService
{
    Task<ExternalResourceDto> CreateExternalResourceAsync(ExtRecourseCreationDto dto);
}