using System.Text;

namespace UIwA;

public class Element
{
    private readonly string _name;
    private readonly StringBuilder _attributes = new StringBuilder();
    private readonly string _value;
    public List<Element> Children { get; } = new List<Element>();

    public static Element CreateTextNode(string value)
    {
        return new Element(string.Empty, value);
    }

    public static Element CreateElement(string name)
    {
        return new Element(name, string.Empty);
    }

    private Element(string name, string value)
    {
        _name = name;
        _value = value;
    }

    public void SetAttribute(string name, string value)
    {
        _attributes.Append(" ");
        _attributes.Append(name);
        _attributes.Append("='");
        _attributes.Append(value);
        _attributes.Append("'");
    }

    public void AppendChild(Element childNode)
    {
        Children.Add(childNode);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        AppendContentTo(result);
        return result.ToString();
    }

    public void AppendContentTo(StringBuilder xmlResult)
    {
        if (Children.Count == 0 && string.IsNullOrEmpty(_value))
        {
            xmlResult.Append("<" + _name + "/>");
            return;
        }

        if (string.IsNullOrEmpty(_name))
        {
            xmlResult.Append(_value);
            return;
        }

        xmlResult.Append("<" + _name + _attributes + ">");
        foreach (var child in Children)
        {
            xmlResult.Append(child.ToString());
        }
        xmlResult.Append(_value);
        xmlResult.Append("</" + _name + ">");
    }
}