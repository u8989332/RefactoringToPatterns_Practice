namespace MCKtoF;

public class DecodingStringNode : Node
{
    internal StringNode StringNode { get; }

    public DecodingStringNode(StringNode stringNode)
    {
        StringNode = stringNode;
    }
}