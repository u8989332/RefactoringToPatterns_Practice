using System.Text;

namespace MEtD;

public class StringNode : AbstractNode
{
    protected internal StringNode(StringBuilder textBuffer, int textBegin, int textEnd) : base(textBuffer, textBegin, textEnd)
    {
    }

    public static INode CreateStringNode(StringBuilder textBuffer, int textBegin, int textEnd, bool shouldDecodeNodes)
    {
        if (shouldDecodeNodes)
        {
            return new DecodingNode(new StringNode(textBuffer, textBegin, textEnd));
        }
        return new StringNode(textBuffer, textBegin, textEnd);
    }

    public override string ToPlainTextString()
    {
        return TextBuffer.ToString();
    }

    public override string ToHtml()
    {
        throw new NotImplementedException();
    }
}