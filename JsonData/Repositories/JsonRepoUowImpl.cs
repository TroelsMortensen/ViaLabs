using Application.RepositoryContracts;

namespace JsonData.Repositories;

public class JsonRepoUowImpl : IRepoUOW
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }

    private readonly IDbContext context;

    public JsonRepoUowImpl(ICategoryRepo categoryRepo, IGuideRepo guideRepo, ITeacherRepo teacherRepo, IDbContext context)
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