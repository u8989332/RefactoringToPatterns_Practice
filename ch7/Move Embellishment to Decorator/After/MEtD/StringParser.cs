using System.Text;

namespace MEtD;

public class StringParser
{
    public INode Find(NodeReader reader, string input, int position, bool balanceQuotes)
    {
        // simplify
        StringBuilder textBuffer = new StringBuilder();
        int textBegin = 0;
        int textEnd = 0;
        return StringNode.CreateStringNode(textBuffer, textBegin, textEnd, reader.Parser.ShouldDecodeNodes);
    }
}