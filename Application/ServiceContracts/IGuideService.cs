using Application.DTOs.GuideDTOs;
using Entities;

namespace Application.ServiceContracts;

public interface IGuideService
{
    public Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide);

}