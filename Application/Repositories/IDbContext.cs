namespace Application.Repositories;

public interface IDbContext
{
    Task SaveChangesAsync();
}