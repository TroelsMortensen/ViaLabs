using Domain.Aggregates;
using JsonData.JsonSerializationUtils;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class JsonTests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void TestJson()
    {
        SystemNetJsonSerializerHelper helper = new();
        Teacher t = Teacher.Create("VIA\\TRMO").Value;

        string tAsJson = helper.Serialize(t);
        
        Teacher result = helper.Deserialize<Teacher>(tAsJson);
        Console.WriteLine(result.Name);
    }
}