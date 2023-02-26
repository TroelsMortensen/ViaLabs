namespace Application.RepositoryContracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}