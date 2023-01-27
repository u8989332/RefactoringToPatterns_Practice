using System.Text;

namespace MCKtoF
{
    public class StringParser
    {
        public Node Find(StringBuilder textBuffer, int textBegin, int textEnd, Parser parser)
        {
            return parser.NodeFactory.CreateStringNode(textBuffer, textBegin, textEnd);
        }
    }
}
