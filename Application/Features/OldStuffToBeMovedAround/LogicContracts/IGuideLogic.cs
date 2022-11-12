using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface IGuideLogic
{
    public Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide);

}