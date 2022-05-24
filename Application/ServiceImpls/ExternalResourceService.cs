using Application.DTOs.ExternalResourceDTOs;
using Application.RepositoryContracts;
using Application.ServiceContracts;

namespace Application.ServiceImpls;

public class ExternalResourceService : IExternalResourceService
{
    private readonly IExternalResourceRepo extResRepo;

    public ExternalResourceService(IExternalResourceRepo extResRepo)
    {
        this.extResRepo = extResRepo;
    }

    public Task<ExternalResourceDto> CreateExternalResourceAsync(ExtRecourseCreationDto dto)
    {
        throw new NotImplementedException();
    }
}