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

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}