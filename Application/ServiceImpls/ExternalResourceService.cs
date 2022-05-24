using System.ComponentModel.DataAnnotations;
using Application.DTOs.ExternalResourceDTOs;
using Application.Exceptions;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Entities;

namespace Application.ServiceImpls;

public class ExternalResourceService : IExternalResourceService
{
    private readonly IRepoUOW repoUow;

    public ExternalResourceService(IRepoUOW repoUow)
    {
        this.repoUow = repoUow;
    }

    public async Task<ExternalResourceDto> CreateExternalResourceAsync(ExtRecourseCreationDto dto)
    {
        ValidateExternalResourceData(dto);
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

        try
        {
            await Create(er);
        }
        catch (Exception)
        {
            await repoUow.RollbackAsync();
            throw;
        }
        
        return new ExternalResourceDto
        {
            Id = id,
            OwnerId = dto.OwnerId,
            Title = dto.Title,
            Url = dto.Url,
            Description = dto.Description,
            CategoryId = dto.CategoryId
        };
    }
    
    private async Task Create(ExternalResource er)
    {
        await repoUow.BeginAsync();
        await repoUow.ExternalResourceRepo.CreateAsync(er);
        await repoUow.SaveChangesAsync();
    }

    private void ValidateExternalResourceData(ExtRecourseCreationDto dto)
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