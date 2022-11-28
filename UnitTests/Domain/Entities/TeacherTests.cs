using Domain.Entities;
using SharedKernel.OperationResult;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class TeacherTests
{
    [Test] // the teachers name is currently given by the Blazor login framework...
    public void CanNotCreateTeacherWithEmptyName()
    {
        Result<Teacher> result = Teacher.Create(null);
        Assert.True(result.HasErrors);
    }
}