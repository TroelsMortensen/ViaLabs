using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.LogicContracts;
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

    public async Task<ExternalResourceDisplayDto> CreateAsync(ExtRecourseCreationDto dto)
    {
        Guid id = Guid.NewGuid();
        
        ExternalResource er = new ()
        {
            Id = id,
            OwnerId = dto.OwnerId,
            Title = dto.Title,
            Url = dto.Url,
            Description = dto.Description,
            CategoryId = dto.CategoryId
        };
        ValidateExternalResourceData(er);

        try
        {
            await Create(er);
        }
        catch (Exception)
        {
            await repoManager.RollbackAsync();
            throw;
        }
        
        return new ExternalResourceDisplayDto
        {
            Id = id,
            Title = dto.Title,
            Url = dto.Url,
            Description = dto.Description,
        };
    }

    public async Task UpdateAsync(ExternalResourceDisplayDto dto)
    {
        ExternalResource er = new ()
        {
            Id = dto.Id,
            Title = dto.Title,
            Url = dto.Url,
            Description = dto.Description,
        };
        ValidateExternalResourceData(er);

        try
        {
            await repoManager.BeginAsync();
            await repoManager.ExternalResourceRepo.UpdateAsync(er);
            await repoManager.SaveChangesAsync();
        }
        catch (Exception)
        {
            await repoManager.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(ExternalResourceDisplayDto dto)
    {
        try
        {
            await repoManager.BeginAsync();
            await repoManager.ExternalResourceRepo.DeleteAsync(dto.Id);
            await repoManager.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoManager.RollbackAsync();
            throw;
        }
    }

    private async Task Create(ExternalResource er)
    {
        await repoManager.BeginAsync();
        await repoManager.ExternalResourceRepo.CreateAsync(er);
        await repoManager.SaveChangesAsync();
    }

    private void ValidateExternalResourceData(ExternalResource dto)
    {
        ICollection<string> errors = new List<string>();
        if (string.IsNullOrEmpty(dto.Title))
        {
            errors.Add("Title cannot be empty");
        }

        if (dto.Title.Length > 100)
        {
            errors.Add("Title must be less than 100 characters");
        }

        if (string.IsNullOrEmpty(dto.Url))
        {
            errors.Add("The Url cannot be empty");
        }

        if (errors.Any())
        {
            throw new DataValidationException("Invalid data:", errors);
        }
    }
}