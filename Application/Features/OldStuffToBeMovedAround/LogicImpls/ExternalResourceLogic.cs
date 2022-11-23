using Application.Features.ProfileDataLogic.DTOs;
using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.Features.SharedDtos;
using Application.RepositoryContracts;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class ExternalResourceLogic : IExternalResourceLogic
{
    private readonly IRepoManager repoManager;

    public ExternalResourceLogic(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<ExternalResourceDisplayDto> CreateAsync(ExtResCreationRequest request)
    {
        throw new NotImplementedException();
        // Guid id = Guid.NewGuid();
        //
        // ExternalResource er = new(request.Title, request.Url);
        // // TODO attach to Category by getting category, adding this.
        //
        // ValidateExternalResourceData(er);
        //
        // await Create(er);
        //
        //
        // ExternalResourceDisplayDto returnValue = new(id, request.Title, request.Url, request.Description);
        //
        // return returnValue;
    }

    public async Task UpdateAsync(ExtResUpdateRequest request)
    {
        throw new NotImplementedException();
        // ValidateExternalResourceData(request);
        //
        // try
        // {
        //     await repoManager.BeginAsync();
        //     await repoManager.ExternalResourceRepo.UpdateAsync(er);
        //     await repoManager.SaveChangesAsync();
        // }
        // catch (Exception)
        // {
        //     await repoManager.RollbackAsync();
        //     throw;
        // }
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
        // try
        // {
        //     await repoManager.ExternalResourceRepo.DeleteAsync(dto.Id);
        // }
        // catch (Exception e)
        // {
        //     await repoManager.RollbackAsync();
        //     throw;
        // }
    }

    private async Task Create(ExternalResource er)
    {
        throw new NotImplementedException();
        // await repoManager.BeginAsync();
        // await repoManager.ExternalResourceRepo.CreateAsync(er);
        // await repoManager.SaveChangesAsync();
    }

    // private void ValidateExternalResourceData(ExtResUpdateRequest dto)
    // {
    //
    // }
}