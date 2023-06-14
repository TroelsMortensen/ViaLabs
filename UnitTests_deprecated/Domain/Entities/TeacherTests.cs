using Domain.Entities;
using Domain.OperationResult;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class TeacherTests
{
    [Test] // the teachers name is currently given by the Blazor login framework...
    public void TeacherCreate_NameIsNull_ReturnsError()
    {
        Result<Teacher> result = Teacher.Create(null);

        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
        });
    }

    [TestCase("")]
    [TestCase("a")]
    [TestCase("ab")]
    public void TeacherCreate_NameIsLessThan3Letters_ReturnsError(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors, "1");
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"), "2");
        });
    }

    [TestCase(" ")]
    [TestCase("   ")]
    [TestCase("      ")]
    public void TeacherCreate_NameIsOnlySpaces_ReturnsError(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
        });
    }

    [TestCase(" abc ")]
    [TestCase("  abcasf  ")]
    [TestCase(" abcasf  ")]
    public void TeacherCreate_NameHasLeadingAndOrTrailingSpaces_ReturnsTeacherWithTrimmedName(string name)
    {
        var result = Teacher.Create(name);
        Assert.That(result.Value.Name, Is.EqualTo(name.Trim(' ')));
    }

    [TestCase("abc")]
    [TestCase("abcefgh")]
    [TestCase("abcefghijklmnop")]
    public void TeacherCreate_InputValidName_ReturnsTeacher(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.False(result.HasErrors);
    }

    [TestCase("abcefghijklmnopq")]
    [TestCase("abce f1g2h34ij6klm n65 opq")]
    [TestCase("asd 4 at4ajajf8 0j8afjda 8fda  a7d")]
    public void TeacherCreate_NameMoreThan15Letters_ReturnsError(string name)
    {
        Result<Teacher> result = Teacher.Create(name);
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Teacher.Name"));
        });
    }
}