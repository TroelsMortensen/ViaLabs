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

    [Fact]
    public void CategoryEquals_TwoDifferentCategoryIdsWithSameStringValue_AreEqual()
    {
        string guidAsString = Guid.NewGuid().ToString();
        CategoryId first = CategoryId.FromString(guidAsString);
        CategoryId second = CategoryId.FromString(guidAsString);
        Assert.Equal(first, second);
    }    
    
    [Fact]
    public void CategoryEquals_TwoDifferentCategoryIdsWithSameGuidValue_AreEqual()
    {
        Guid guid = Guid.NewGuid();
        CategoryId first = CategoryId.FromGuid(guid);
        CategoryId second = CategoryId.FromGuid(guid);
        Assert.Equal(first, second);
    }
}