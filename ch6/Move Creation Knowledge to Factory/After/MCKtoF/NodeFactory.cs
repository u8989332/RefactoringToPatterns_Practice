using System.Text;

namespace MCKtoF
{
    public class NodeFactory
    {
        public bool ShouldDecodeNodes { get; set; } = false;
        public Node CreateStringNode(StringBuilder textBuffer, int textBegin, int textEnd)
        {
            if (ShouldDecodeNodes)
            {
                return new DecodingStringNode(new StringNode(textBuffer, textBegin, textEnd));
            }

            return new StringNode(textBuffer, textBegin, textEnd);
        }
    }
}
