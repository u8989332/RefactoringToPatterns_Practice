using System.Text;

namespace UIwA;

public class XMLBuilder : AbstractBuilder
{
    public XMLBuilder(string rootTagName)
    {
        RootNode = new TagNode(rootTagName);
        Current = RootNode;
    }

    public void AddAttribute(string name, string value)
    {
        Current.AddAttribute(name, value);
    }

    public void AddValue(string value)
    {
        Current.AddValue(value);
    }

    public string ToXml()
    {
        StringBuilder xmlResult = new StringBuilder();
        RootNode.AppendContentTo(xmlResult);
        return xmlResult.ToString();
    }

    protected override IXMLNode CreateNode(string childName)
    {
        return new TagNode(childName);
    }

    public override void AddSibling(string siblingName)
    {
        var parent = ((TagNode)Current).Parent;
        Current = CreateNode(siblingName);
        parent.Add(Current);
    }
}