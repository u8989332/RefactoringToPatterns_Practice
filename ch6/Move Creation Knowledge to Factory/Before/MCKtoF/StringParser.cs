using System.Text;

namespace MCKtoF
{
    public class StringParser
    {
        public Node Find(StringBuilder textBuffer, int textBegin, int textEnd, Parser parser)
        {
            return StringNode.CreateStringNode(textBuffer, textBegin, textEnd, parser.ShouldDecodeNodes);
        }
    }
}
