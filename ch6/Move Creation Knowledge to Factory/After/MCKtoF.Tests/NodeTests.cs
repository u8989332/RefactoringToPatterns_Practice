using System.Text;

namespace MCKtoF.Tests
{
    public class NodeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DecodingNodeTest()
        {
            // arrange
            StringBuilder textBuffer = new StringBuilder();
            int textBegin = 1, textEnd = 2;
            NodeFactory decodeNodes = new NodeFactory();
            decodeNodes.ShouldDecodeNodes = true;
            Parser parser = new Parser();
            parser.NodeFactory = decodeNodes;
            StringParser stringParser = new StringParser();

            // act
            var node = stringParser.Find(textBuffer, textBegin, textEnd, parser);

            // assert 
            var convertNode = node as DecodingStringNode;
            Assert.IsNotNull(convertNode);
            var stringNode = convertNode?.StringNode;
            Assert.AreEqual(textBegin, stringNode.TextBegin);
            Assert.AreEqual(textEnd, stringNode.TextEnd);
            Assert.AreEqual(textBuffer, stringNode.TextBuffer);
        }

        [Test]
        public void StringNodeTest()
        {
            // arrange
            StringBuilder textBuffer = new StringBuilder(5);
            int textBegin = 3, textEnd = 4;
            NodeFactory decodeNodes = new NodeFactory();
            decodeNodes.ShouldDecodeNodes = false;
            Parser parser = new Parser();
            parser.NodeFactory = decodeNodes;
            StringParser stringParser = new StringParser();

            // act
            var node = stringParser.Find(textBuffer, textBegin, textEnd, parser);

            // assert 
            var stringNode = node as StringNode;
            Assert.IsNotNull(stringNode);
            Assert.AreEqual(textBegin, stringNode.TextBegin);
            Assert.AreEqual(textEnd, stringNode.TextEnd);
            Assert.AreEqual(textBuffer, stringNode.TextBuffer);
        }
    }
}