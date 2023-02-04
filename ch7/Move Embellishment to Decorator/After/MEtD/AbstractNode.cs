using System.Text;

namespace MEtD;

public class AbstractNode : INode
{
    protected readonly StringBuilder TextBuffer;
    protected readonly int TextBegin;
    protected readonly int TextEnd;

    protected AbstractNode(StringBuilder textBuffer, int textBegin, int textEnd)
    {
        TextBuffer = textBuffer;
        TextBegin = textBegin;
        TextEnd = textEnd;
    }

    public string Text
    {
        get
        {
            return null;
        }
        set
        {

        }
    }

    public virtual string ToPlainTextString()
    {
        // simplify
        throw new NotImplementedException();
    }

    public virtual string ToHtml()
    {
        // simplify
        throw new NotImplementedException();
    }
}