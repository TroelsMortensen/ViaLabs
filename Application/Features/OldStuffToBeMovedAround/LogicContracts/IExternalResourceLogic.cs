﻿using Application.Features.ProfileDataLogic.DTOs;
using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.SharedDtos;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface IExternalResourceLogic
{
    Task<ExternalResourceDisplayDto> CreateAsync(ExtResCreationRequest request);
    Task UpdateAsync(ExtResUpdateRequest request);
    Task DeleteAsync(Guid id);
}