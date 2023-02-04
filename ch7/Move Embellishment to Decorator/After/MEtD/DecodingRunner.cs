using System.Text;

namespace MEtD
{
    public class DecodingRunner
    {
        public string GetResult(string stringToDecode)
        {
            StringBuilder decodedContent = new StringBuilder();
            Parser parser = Parser.CreateParser(stringToDecode);
            parser.ShouldDecodeNodes = true;

            NodeIterator nodes = parser.Elements;
            while (nodes.HasMoreNodes())
            {
                decodedContent.Append(nodes.NextNode().ToPlainTextString());
            }

            return decodedContent.ToString();
        }
    }
}
