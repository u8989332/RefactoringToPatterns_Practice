using System.Text;

namespace UIwA;

public class ElementAdapter : IXMLNode
{
    private readonly Document _document;
    public Element Element { get; }

    public ElementAdapter(Element element, Document document)
    {
        _document = document;
        Element = element;
    }

    public void AddAttribute(string name, string value)
    {
        Element.SetAttribute(name, value);
    }

    public void Add(IXMLNode child)
    {
        ElementAdapter childElement = (ElementAdapter)child;
        Element.AppendChild(childElement.Element);
    }

    public void AddValue(string value)
    {
        Element.AppendChild(_document.CreateTextNode(value));
    }

    public void AppendContentTo(StringBuilder xmlResult)
    {
        Element.AppendContentTo(xmlResult);
    }
}