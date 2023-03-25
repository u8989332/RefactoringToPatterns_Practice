namespace UnifyInterfaces.Tests
{
    public class NodeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNode()
        {
            // arrange
            AbstractNode node = new StringNode();

            // act
            string result = node.GetText();

            // assert
            Assert.AreEqual("tag", result);
        }
    }
}