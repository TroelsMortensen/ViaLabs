using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;
using Application.Features.SharedDtos;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface IGuideLogic
{
    public Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide);

}