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

    [Fact]
    public void CategoryCreate_WithProvidedId_ReturnsValidId()
    {
        Guid newGuid = Guid.NewGuid();
        CategoryId id = CategoryId.FromString(newGuid.ToString());
        Assert.Equal(newGuid, id.Value);
    }
}