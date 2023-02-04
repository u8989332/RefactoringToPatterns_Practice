namespace MEtD;

public class DecodingNode : INode
{
    private INode _delegate;
    protected internal DecodingNode(INode newDelegate)
    {
        _delegate = newDelegate;
    }

    public string Text { get; set; }

    public string ToPlainTextString()
    {
        return Translate.Decode(_delegate.ToPlainTextString());
    }

    public string ToHtml()
    {
        throw new NotImplementedException();
    }
}