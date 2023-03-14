using System.Text;

namespace UIwA;

public class DOMBuilder : AbstractBuilder
{
    private Document _document;
    private IXMLNode _parent;

    public void AddAttribute(string name, string value)
    {
        Current.AddAttribute(name, value);
    }

    public DOMBuilder(string rootTagName)
    {
        _document = new Document();
        RootNode = CreateNode(rootTagName);
        Current = RootNode;
    }

    protected override IXMLNode CreateNode(string childName)
    {
        return new ElementAdapter(_document.CreateElement(childName), _document);
    }

    public override void AddSibling(string siblingName)
    {
        if (Current == RootNode)
        {
            throw new InvalidDataException("Wrong beside");
        }

        var siblingNode = CreateNode(siblingName);
        ((ElementAdapter)_parent).Element.AppendChild(((ElementAdapter)siblingNode).Element);
        Current = siblingNode;
    }

    protected override void SetParent(IXMLNode node)
    {
        _parent = node;
    }

    public void AddValue(string value)
    {
        Current.AddValue(value);
    }

    public string ToXml()
    {
        StringBuilder xmlResult = new StringBuilder();
        ((ElementAdapter)RootNode).Element.AppendContentTo(xmlResult);
        return xmlResult.ToString();
    }
}