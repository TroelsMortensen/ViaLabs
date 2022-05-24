namespace Application.RepositoryContracts;

public interface IRepoUOW
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }

    public IExternalResourceRepo ExternalResourceRepo { get; set; }

    Task BeginAsync();
    Task SaveChangesAsync();
    Task RollbackAsync();
}