using System.Text;

namespace MEtD;

public class StringNode : AbstractNode
{
    private readonly bool _shouldDecodeNodes;

    public StringNode(StringBuilder textBuffer, int textBegin, int textEnd, bool shouldDecodeNodes) : base(textBuffer, textBegin, textEnd)
    {
        _shouldDecodeNodes = shouldDecodeNodes;
    }

    public override string ToPlainTextString()
    {
        string result = TextBuffer.ToString();
        if (_shouldDecodeNodes)
        {
            result = Translate.Decode(result);
        }

        return result;
    }

    public override string ToHtml()
    {
        throw new NotImplementedException();
    }
}