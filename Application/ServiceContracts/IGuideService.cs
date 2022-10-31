using Application.DTOs.GuideDTOs;

namespace Application.ServiceContracts;

public interface IGuideService
{
    public Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide);

}