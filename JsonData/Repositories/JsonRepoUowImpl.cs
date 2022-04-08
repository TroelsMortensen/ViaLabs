using Application.RepositoryContracts;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class JsonRepoUowImpl : IRepoUOW
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }

    private readonly JsonDataContext context;

    public JsonRepoUowImpl(ICategoryRepo categoryRepo, IGuideRepo guideRepo, ITeacherRepo teacherRepo, JsonDataContext context)
    {
        CategoryRepo = categoryRepo;
        GuideRepo = guideRepo;
        TeacherRepo = teacherRepo;
        this.context = context;
    }

    public Task BeginAsync()
    {
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public Task RollbackAsync()
    {
        context.Clear();
        return Task.CompletedTask;
    }
}