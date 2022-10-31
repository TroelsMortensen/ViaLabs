using System.ComponentModel.DataAnnotations;
using Application.DTOs.ExternalResourceDTOs;
using Application.Exceptions;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Domain.Models;

namespace Application.ServiceImpls;

public class ExternalResourceService : IExternalResourceService
{
    private readonly IRepoUOW repoUow;

    public ExternalResourceService(IRepoUOW repoUow)
    {
        this.repoUow = repoUow;
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
            await repoUow.RollbackAsync();
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
            await repoUow.BeginAsync();
            await repoUow.ExternalResourceRepo.UpdateAsync(er);
            await repoUow.SaveChangesAsync();
        }
        catch (Exception)
        {
            await repoUow.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(ExternalResourceDisplayDto dto)
    {
        try
        {
            await repoUow.BeginAsync();
            await repoUow.ExternalResourceRepo.DeleteAsync(dto.Id);
            await repoUow.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoUow.RollbackAsync();
            throw;
        }
    }

    private async Task Create(ExternalResource er)
    {
        await repoUow.BeginAsync();
        await repoUow.ExternalResourceRepo.CreateAsync(er);
        await repoUow.SaveChangesAsync();
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