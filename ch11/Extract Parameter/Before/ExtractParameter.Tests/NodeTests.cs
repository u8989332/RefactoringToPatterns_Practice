using System.Text;

namespace ExtractParameter.Tests
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
            StringBuilder sb = new StringBuilder();
            int textBegin = 1;
            int textEnd = 5;

            // act
            DecodingNode node = new DecodingNode(sb, textBegin, textEnd);
            StringNode stringNode = node.CurDelegate as StringNode;

            // assert
            Assert.IsNotNull(stringNode);
            Assert.AreEqual(sb, stringNode.TextBuilder);
            Assert.AreEqual(textBegin, stringNode.TextBegin);
            Assert.AreEqual(textEnd, stringNode.TextEnd);
        }
    }
}