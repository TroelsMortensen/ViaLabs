namespace Application.RepositoryContracts;

public interface IRepoManager
{
    public ICategoryRepo CategoryRepo { get;  }
    public IGuideRepo GuideRepo { get; }
    public ITeacherRepo TeacherRepo { get; }

    public IExternalResourceRepo ExternalResourceRepo { get; }


}