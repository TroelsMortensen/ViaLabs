using Application.DTOs.ExternalResourceDTOs;

namespace Application.ServiceContracts;

public interface IExternalResourceService
{
    Task<ExternalResourceDisplayDto> CreateExternalResourceAsync(ExtRecourseCreationDto dto);
}