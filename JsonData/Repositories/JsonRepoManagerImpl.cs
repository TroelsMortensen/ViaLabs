using Application.RepositoryContracts;
using JsonData.Context;

namespace JsonData.Repositories;

public class JsonRepoManagerImpl : IRepoManager
{
    public ICategoryRepo CategoryRepo { get; set; }
    public IGuideRepo GuideRepo { get; set; }
    public ITeacherRepo TeacherRepo { get; set; }
    public IExternalResourceRepo ExternalResourceRepo { get; set; }


    public JsonRepoManagerImpl(ICategoryRepo categoryRepo, IGuideRepo guideRepo, ITeacherRepo teacherRepo,IExternalResourceRepo externalResourceRepo)
    {
        CategoryRepo = categoryRepo;
        GuideRepo = guideRepo;
        TeacherRepo = teacherRepo;
        ExternalResourceRepo = externalResourceRepo;
    }
}