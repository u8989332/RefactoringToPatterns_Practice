using System.Text;

namespace UIwA;

public class DOMBuilder : AbstractBuilder
{
    private Document _document;
    private Element _root;
    private Element _parent;
    private Element _current;

    public void AddAttribute(string name, string value)
    {
        _current.SetAttribute(name, value);
    }

    public DOMBuilder(string rootTagName)
    {
        _document = new Document();
        _root = Element.CreateElement(rootTagName);
        _current = _root;
    }

    public void AddBelow(string child)
    {
        Element childNode = _document.CreateElement(child);
        _current.AppendChild(childNode);
        _parent = _current;
        _current = childNode;
    }

    public void AddBeside(string sibling)
    {
        if (_current == _root)
        {
            throw new InvalidDataException("Wrong beside");
        }

        Element siblingNode = _document.CreateElement(sibling);
        _parent.AppendChild(siblingNode);
        _current = siblingNode;
    }

    public void AddValue(string value)
    {
        _current.AppendChild(_document.CreateTextNode(value));
    }

    public string ToXml()
    {
        StringBuilder xmlResult = new StringBuilder();
        _root.AppendContentTo(xmlResult);
        return xmlResult.ToString();
    }
}