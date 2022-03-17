namespace Application.Repositories;

public interface IRepoManager
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }

    Task SaveChangesAsync();
}