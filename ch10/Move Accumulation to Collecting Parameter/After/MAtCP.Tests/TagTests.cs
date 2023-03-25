namespace MAtCP.Tests;

public class TagTests
{
    private const string SAMPLE_PRICE = "8.95";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSimpleTagWithOneAttributeAndValue()
    {
        // arrange
        string expectXml = "<price currency=" + "'" + "USD" + "'>" + SAMPLE_PRICE + "</price>";

        // act
        TagNode priceTag = new TagNode("price");
        priceTag.AddAttribute("currency", "USD");
        priceTag.AddValue(SAMPLE_PRICE);

        // assert
        Assert.AreEqual(expectXml, priceTag.ToString());
    }

    [Test]
    public void TestCompositeTagOneChild()
    {
        // arrange
        string expectXml = "<product><price></price></product>";

        // act
        TagNode productTag = new TagNode("product");
        productTag.Add(new TagNode("price"));

        // assert
        Assert.AreEqual(expectXml, productTag.ToString());
    }

    [Test]
    public void TestAddingChildrenAndGrandchildren()
    {
        // arrange
        string expectXml = "<orders><order><product></product></order></orders>";

        // act
        TagNode ordersTag = new TagNode("orders");
        TagNode orderTag = new TagNode("order");
        TagNode productTag = new TagNode("product");
        ordersTag.Add(orderTag);
        orderTag.Add(productTag);

        // assert
        Assert.AreEqual(expectXml, ordersTag.ToString());
    }
}