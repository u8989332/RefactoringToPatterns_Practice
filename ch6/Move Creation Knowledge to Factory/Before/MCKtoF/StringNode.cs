using System.Text;

namespace MCKtoF;

public class StringNode : Node
{
    internal StringBuilder TextBuffer;
    internal int TextBegin;
    internal int TextEnd;

    public StringNode(StringBuilder textBuffer, int textBegin, int textEnd)
    {
        TextBuffer = textBuffer;
        TextBegin = textBegin;
        TextEnd = textEnd;
    }

    public static Node CreateStringNode(StringBuilder textBuffer, int textBegin, int textEnd, bool shouldDecodeNodes)
    {
        if (shouldDecodeNodes)
        {
            return new DecodingStringNode(new StringNode(textBuffer, textBegin, textEnd));
        }

        return new StringNode(textBuffer, textBegin, textEnd);
    }
}