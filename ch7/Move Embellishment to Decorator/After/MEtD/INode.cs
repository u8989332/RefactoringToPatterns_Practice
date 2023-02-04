namespace MEtD;

public interface INode
{
    public string Text { get; set; }
    public string ToPlainTextString();
    public string ToHtml();
}