using Domain.OperationResult;
using Domain.Values;

namespace Tests.ByValues;

public class TeacherNameTests
{

    [Fact]
    public void Create_Teacher_With_Valid_Name_Is_Good()
    {
        Result<TeacherName> result = TeacherName.Create("VIA\\TRMO");
        Assert.NotEmpty(result.Value.Value);
        Assert.Equal("VIA\\TRMO", result.Value.Value);
    }

    [Fact]
    public void Create_Teacher_With_Short_Name_Fails()
    {
        var result = TeacherName.Create("ab");
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Create_Teacher_With_Long_Name_Fails()
    {
        var result = TeacherName.Create("abcdefghijklmopqrstu");
        Assert.True(result.IsFailure);
    }
    
}