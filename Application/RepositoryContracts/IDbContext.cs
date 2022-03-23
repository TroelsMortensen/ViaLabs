namespace Application.RepositoryContracts;

public interface IDbContext
{
    Task SaveChangesAsync();
}