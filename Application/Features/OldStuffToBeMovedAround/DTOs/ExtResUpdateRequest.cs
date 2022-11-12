namespace Application.Features.ProfileDataLogic.DTOs;

public record ExtResUpdateRequest(Guid Id, string? Title, string? Url, string? Description);