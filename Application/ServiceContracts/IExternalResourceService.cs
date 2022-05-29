using Application.DTOs.ExternalResourceDTOs;

namespace Application.ServiceContracts;

public interface IExternalResourceService
{
    Task<ExternalResourceDisplayDto> CreateAsync(ExtRecourseCreationDto dto);
    Task UpdateAsync(ExternalResourceDisplayDto resource);
}