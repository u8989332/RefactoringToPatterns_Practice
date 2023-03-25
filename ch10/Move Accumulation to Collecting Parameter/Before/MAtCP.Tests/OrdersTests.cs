namespace MAtCP.Tests
{
    public class OrdersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestXml()
        {
            // arrange
            Orders orders = new Orders();
            var order = new Order("order1");
            order.Add(new Product(1, 10, "Apple", 5.95));
            orders.Add(order);
            OrdersWriter writer = new OrdersWriter(orders);

            // act
            string result = writer.GetContent();

            // assert
            Assert.AreEqual("<orders><order id='order1'><product id='1' color='red' size='medium'><price currency='USD'>5.95</price>Apple</product></order></orders>", result);
        }
    }
}