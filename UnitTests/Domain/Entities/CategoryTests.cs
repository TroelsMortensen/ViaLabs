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
    [TestCase("$000000")]
    [TestCase("%000000")]
    [TestCase("/000000")]
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
    public void ColorStartsWithHashIsGood3DigitsSunny()
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
    
    #endregion
}