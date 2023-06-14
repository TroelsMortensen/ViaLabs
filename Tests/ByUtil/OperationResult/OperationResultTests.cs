using Domain.OperationResult;

namespace Tests.ByUtil.OperationResult;

public class OperationResultTests
{
    [Fact]
    public void ResultRequire_CanChainRequire()
    {
        Result result = Result.Validation()
            .Require(() => 1 == 1, "Attr", "Error");
    }

    [Fact]
    public void ResultValidation_ValidConditions_ResultIsSuccess()
    {
        Result result = Result.Validation()
            .Require(() => 1 == 1, "Attr", "Error")
            .Require(() => !string.IsNullOrEmpty("Hello world"), "Attr1", "Error1");

        Assert.True(result.IsSuccess);
    }


    [Theory]
    [MemberData(nameof(FailureData))]
    public void ResultValidation_SingleInvalidCondition_ResultIsFailure(List<Func<bool>> funcs)
    {
        Result result = Result.Validation();
        foreach (Func<bool> func in funcs)
        {
            result.Require(func, "Attr", "Error");
        }

        Assert.True(result.IsFailure);
    }

    public static List<object[]> FailureData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new List<Func<bool>>()
                {
                    () => 1 == 2
                }
            },
            new object[]
            {
                new List<Func<bool>>()
                {
                    () => 1 == 1,
                    () => string.IsNullOrEmpty("hello world")
                }
            },
            new object[]
            {
                new List<Func<bool>>()
                {
                    () => 1 == 2,
                    () => string.IsNullOrEmpty("")
                }
            },
            new object[]
            {
                new List<Func<bool>>()
                {
                    () => 1 == 1,
                    () => string.IsNullOrEmpty(""),
                    () => false
                }
            },
            new object[]
            {
                new List<Func<bool>>()
                {
                    () => 1 == 2,
                    () => string.IsNullOrEmpty("hello world"),
                    () => false
                }
            }
        };
    }
}