using Domain.OperationResult;

namespace UnitTests.SharedKernel.OperationResult;

[TestFixture]
public class ResultTests
{
    [TestCase("")]
    public void TestUnderDev(string title)
    {
        string attr = "Category.Title";
        Result result = new Result()
            .ThenValidate(string.IsNullOrEmpty(title), attr, "Title cannot be empty")
            .ThenValidate(title.Length < 3, attr, "Title must be 3 or more characters")
            ;

    }
    
}