using Domain.Aggregates;
using Domain.OperationResult;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class CategoryTests
{
    #region Category.Title tests

    /**
     * Testing Category.Tilte below
     */
    [Test]
    public void CategoryCreate_NullTitle_ReturnsError()
    {
        Result<Category> result = Category.Create(null, "#000000", "", Guid.NewGuid());
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }

    [Test]
    public void CategoryCreate_EmptyTitle_ReturnsError()
    {
        Result<Category> result = Category.Create("", "#000000", "", Guid.NewGuid());
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }

    [TestCase("a")]
    [TestCase("ab")]
    public void CategoryCreate_TitleLessThan3Letters_ReturnsError(string name)
    {
        var result = Category.Create(name, "#000000", "", Guid.NewGuid());
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }

    [TestCase(" ")]
    [TestCase("    ")]
    [TestCase("       ")]
    public void CategoryCreate_TitleIsJustEmptySpaces_ReturnsError(string title)
    {
        var result = Category.Create(title, "#000000", "", Guid.NewGuid());
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }

    [TestCase(" abc ")]
    [TestCase("  abcasf  ")]
    [TestCase(" abcasf  ")]
    public void CategoryCreate_TitleHasLeadingAndOrTrailingSpaces_ReturnsCategoryWithTrimmedTitle(string title)
    {
        var result = Category.Create(title, "#000000", "", Guid.NewGuid());
        Assert.That(result.Value.Title, Is.EqualTo(title.Trim(' ')));
    }


    [TestCase("abc")]
    [TestCase("abcefgh")]
    [TestCase("abcefghijklmnopqrstuvxyz1")]
    public void CategoryCreate_TitleBetween3And15Letters_ReturnsCategory(string title)
    {
        var result = Category.Create(title, "#000000", "", Guid.NewGuid());
        Assert.False(result.HasErrors);
    }

    [TestCase("abcefghijklmnopqrstuvxyz12")]
    [TestCase("abcefghijklmnopqrstuvxyz134567890")]
    [TestCase("abcefghijklmnopqrstuvxyz1fksdjaflkdjsælfjsailoæfjiaj3jfæ983")]
    public void CategoryCreate_TitleIsMoreThan25Letters_ReturnsError(string title)
    {
        var result = Category.Create(title, "#000000", "", Guid.NewGuid());
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }

    #endregion

    #region Category.BackgroundColor tests

    [TestCase("!000000")]
    [TestCase("@000000")]
    [TestCase("$000")]
    [TestCase("%000000")]
    [TestCase("/000")]
    public void CategoryCreate_ColorStartsNotWithHash_ReturnsError(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
        });
    }

    [Test]
    public void CategoryCreate_ColorStartsWithHas_ReturnsCategory()
    {
        Result<Category> result = Category.Create("Title", "#000000", "", Guid.NewGuid());
        Assert.False(result.HasErrors);
    }

    [Test]
    public void CategoryCreate_ColorStartsWithHashAndHas3Digits_ReturnsCategory()
    {
        Result<Category> result = Category.Create("Title", "#000", "", Guid.NewGuid());
        Assert.False(result.HasErrors);
    }

    [TestCase("#0 0")]
    [TestCase("#0 0000")]
    [TestCase("#0 00 0")]
    [TestCase("#4 a3 b")]
    [TestCase("#4 a32b")]
    public void CategoryCreate_ColorContainsEmptySpaces_ReturnsError(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
        });
    }

    [TestCase("#GGG")]
    [TestCase("#GGGGGG")]
    [TestCase("#ggg")]
    [TestCase("#QQQ")]
    [TestCase("#QQQQQQ")]
    [TestCase("#qqq")]
    [TestCase("#zzz")]
    [TestCase("#zzzZZZ")]
    [TestCase("#lkjeri")]
    [TestCase("#a8#")]
    [TestCase("#3bf6&!")]
    [TestCase("#\\\\\\")]
    public void CategoryCreate_ColorIsBetween0AndF_ReturnsError(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
        });
    }


    [TestCase("#")]
    [TestCase("#0")]
    [TestCase("#00")]
    [TestCase("#0000")]
    [TestCase("#00000")]
    [TestCase("#0000000")]
    [TestCase("#00000000000")]
    public void CategoryCreate_ColorLengthNot4Or7_ReturnsError(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
        });
    }

    [TestCase("#000")]
    [TestCase("#000000")]
    public void CategoryCreate_ColorLengthIs4Or7_ReturnsCategory(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.False(result.HasErrors);
    }

    [TestCase("#000")]
    [TestCase("#000000")]
    [TestCase("#fff")]
    [TestCase("#FFFFFF")]
    [TestCase("#fFfFfF")]
    [TestCase("#021415")]
    [TestCase("#214afe")]
    [TestCase("#abcdef")]
    [TestCase("#024357")]
    [TestCase("#AbCdEf")]
    public void CategoryCreate_InputValidColors_ReturnsCategory(string color)
    {
        Result<Category> result = Category.Create("Title", color, "", Guid.NewGuid());
        Assert.False(result.HasErrors);
    }

    #endregion

    #region Category both arguments tests

    [TestCase("", "")]
    [TestCase("ab", "k3n")]
    [TestCase("a", "123")]
    [TestCase(null, "#a3p")]
    [TestCase("1", "#a3p2jk3j1k23lj2l3kj123k2j3")]
    public void CategoryCreate_BothInputInvalidTitleAndColor_ReturnsError(string title, string color)
    {
        Result<Category> result = Category.Create(title, color, "", Guid.NewGuid());
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.True(result.Errors.Any(error => error.Attribute.Equals("Category.Title")));
            Assert.True(result.Errors.Any(error => error.Attribute.Equals("Category.BackgroundColor")));
        });
    }

    #endregion

    #region Category.Update tests

    [TestCase("abcd", "#015983")]
    [TestCase("Alkjfiddfde", "#ab8d98")]
    [TestCase("Adf Alkjfiddf eadfa  jklj", "#8cb9ef")]
    public void CategoryUpdate_InputValidTitleAndColor_CategoryIsUpdated(string title, string color)
    {
        // arrange
        Category category = Category.Create("Abc", "#999", "", Guid.NewGuid()).Value;
        // act
        Result result = category.Update(title, color);

        Assert.Multiple(() =>
        {
            Assert.False(result.HasErrors);
            Assert.That(category.Title, Is.EqualTo(title));
            Assert.That(category.BackgroundColor, Is.EqualTo(color));
        });
    }

    [TestCase("ab", "#090909")]
    [TestCase("a", "#090909")]
    [TestCase("", "#090909")]
    [TestCase(null, "#090909")]
    [TestCase("abcdefghijkljkjadfadfadfsa", "#090909")]
    [TestCase("abcdefghijkljkjadfadfa1 01 10 dfsa", "#090909")]
    [TestCase("cbad", "#00")]
    [TestCase("cbad", "#0000")]
    [TestCase("cbad", "#0")]
    [TestCase("cbad", "#0000000")]
    [TestCase("cbad", "#0123k0")]
    [TestCase("cbad", "#a72q01")]
    [TestCase("cbad", "#m20")]
    [TestCase("cbad", "")]
    [TestCase("cbad", null)]
    public void CategoryUpdate_InputInvalidTitleAndColor_ReturnsErrorAndDataNotUpdated(string title, string color)
    {
        Category category = Category.Create("Abc", "#999", "", Guid.NewGuid()).Value;
        // act
        Result result = category.Update(title, color);

        //assert
        Assert.Multiple(() =>
        {
            Assert.True(result.HasErrors);
            Assert.That(category.Title, Is.EqualTo("Abc"));
            Assert.That(category.BackgroundColor, Is.EqualTo("#999"));
        });
    }

    #endregion
}