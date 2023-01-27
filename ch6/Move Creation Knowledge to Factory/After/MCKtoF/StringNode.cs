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
}