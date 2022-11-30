using Domain.Entities;
using SharedKernel.OperationResult;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class CategoryTests
{


    #region Category.Title tests
    /**
     * Testing Category.Tilte below
     */
    
    [Test]
    public void TitleCannotBeNullRainy()
    {
        Result<Category> result = Category.Create(null, "#000000");
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }
    
    [Test]
    public void TitleCannotBeEmptyRainy()
    {
        Result<Category> result = Category.Create("", "#000000");
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }
    
    [TestCase("a")]
    [TestCase("ab")]
    public void TitleCannotBeLessThan3LettersRainy(string name)
    {
        var result = Category.Create(name, "#000000");
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.Title"));
    }
    
    [TestCase("abc")]
    [TestCase("abcefgh")]
    [TestCase("abcefghijklmnopqrstuvxyz1")]
    public void CategoryTitleIsValidBetween3And15LettersSunny(string title)
    {
        var result = Category.Create(title, "#000000");
        Assert.False(result.HasErrors);
    }

    [TestCase("abcefghijklmnopqrstuvxyz12")]
    [TestCase("abcefghijklmnopqrstuvxyz134567890")]
    [TestCase("abcefghijklmnopqrstuvxyz1fksdjaflkdjsælfjsailoæfjiaj3jfæ983")]
    public void CategoryTitleMustBeLessThan25CharactersRainy(string title)
    {
        var result = Category.Create(title, "#000000");
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
    public void ColorMustStartWithHashRainy(string color)
    {
        Result<Category> result = Category.Create("Title", color);
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
    }

    [Test]
    public void ColorStartsWithHashIsGood6DigitsSunny()
    {
        Result<Category> result = Category.Create("Title", "#000000");
        Assert.False(result.HasErrors);
    }

    [Test]
    public void ColorStartsWithHashAnd3DigitsSunny()
    {
        Result<Category> result = Category.Create("Title", "#000");
        Assert.False(result.HasErrors);
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
    public void ColorMustBeBetween0AndFRainy(string color)
    {
        Result<Category> result = Category.Create("Title", color);
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
    }

    
    [TestCase("#")]
    [TestCase("#0")]
    [TestCase("#00")]
    [TestCase("#0000")]
    [TestCase("#00000")]
    [TestCase("#0000000")]
    [TestCase("#00000000000")]
    public void ColorLengthMustBe4Or7Rainy(string color)
    {
        Result<Category> result = Category.Create("Title", color);
        Assert.True(result.HasErrors);
        Assert.That(result.Errors.First().Attribute, Is.EqualTo("Category.BackgroundColor"));
    }
    
    [TestCase("#000")]
    [TestCase("#000000")]
    public void ColorLengthOf4Or7Sunny(string color)
    {
        Result<Category> result = Category.Create("Title", color);
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
    public void ValidColorsSunny(string color)
    {
        Result<Category> result = Category.Create("Title", color);
        Assert.False(result.HasErrors);
    }
    
    #endregion

    #region Category.Update tests

    [TestCase("abcd", "#015983")]
    [TestCase("Alkjfiddfde", "#ab8d98")]
    [TestCase("Adf Alkjfiddf eadfa  jklj", "#8cb9ef")]
    public void UpdateWithCorrectDataSunny(string title, string color)
    {
        // arrange
        Category category = Category.Create("Abc", "#999").Value;
        // act
        Result result = category.Update(title, color);
        Assert.False(result.HasErrors);
        Assert.That(category.Title, Is.EqualTo(title));
        Assert.That(category.BackgroundColor, Is.EqualTo(color));
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
    public void UpdateWithInvalidTitleOrColorRainy(string title, string color)
    {
        Category category = Category.Create("Abc", "#999").Value;
        // act
        Result result = category.Update(title, color);
        
        //assert
        Assert.True(result.HasErrors);
        Assert.That(category.Title, Is.EqualTo("Abc"));
        Assert.That(category.BackgroundColor, Is.EqualTo("#999"));
    }

    #endregion
}