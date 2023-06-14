using Domain.Values;

namespace Tests.ByValues;

public class CategoryIdTests
{
    [Fact]
    public void CategoryCreate_WhenCalled_ReturnsValidId()
    {
        CategoryId id = CategoryId.Create();
        Assert.NotNull(id.Value);
    }
}