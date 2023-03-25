using System.Text;

namespace ExtractParameter;

public class StringNode : Node
{
    internal StringBuilder TextBuilder { get; }
    internal int TextBegin { get; set; }
    internal int TextEnd { get; set; }

    public StringNode(StringBuilder textBuilder, int textBegin, int textEnd)
    {
        TextBuilder = textBuilder;
        TextBegin = textBegin;
        TextEnd = textEnd;
    }
}