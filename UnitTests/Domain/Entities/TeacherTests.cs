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
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
    }

    [TestCase("a")]
    [TestCase("ab")]
    public void TeacherNameCannotBeLessThan3Letters(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
    }

    [TestCase("abc")]
    [TestCase("abcefgh")]
    [TestCase("abcefghijklmnop")]
    public void TeacherNameIsValidBetween3And15Letters(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.False(result.HasErrors);
    }

    [Test]
    public void TeacherNameCannotBeMoreThan15Letters()
    {
        Result<Teacher> result = Teacher.Create("abcefghijklmnopq");
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
    }
}