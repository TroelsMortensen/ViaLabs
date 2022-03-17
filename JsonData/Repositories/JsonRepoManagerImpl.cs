using Application.Repositories;

namespace JsonData.Repositories;

public class JsonRepoManagerImpl : IRepoManager
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }

    private IDbContext context;

    public JsonRepoManagerImpl(ICategoryRepo categoryRepo, IGuideRepo guideRepo, ITeacherRepo teacherRepo, IDbContext context)
    {
        CategoryRepo = categoryRepo;
        GuideRepo = guideRepo;
        TeacherRepo = teacherRepo;
        this.context = context;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}