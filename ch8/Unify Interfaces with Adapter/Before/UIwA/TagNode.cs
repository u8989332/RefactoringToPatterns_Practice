using System.Text;

namespace UIwA;

public class TagNode
{
    public StringBuilder Attributes { get; } = new StringBuilder();
    public string TagName { get; }
    public string Value { get; private set; }
    public List<TagNode> Children { get; } = new List<TagNode>();
    public TagNode Parent { get; set; }

    public TagNode(string name)
    {
        TagName = name;
    }

    public void Add(TagNode childNode)
    {
        childNode.Parent = this;
        Children.Add(childNode);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        AppendContentTo(result);
        return result.ToString();
    }

    public void AddAttribute(string name, string value)
    {
        Attributes.Append(" ");
        Attributes.Append(name);
        Attributes.Append("='");
        Attributes.Append(value);
        Attributes.Append("'");
    }

    public void AddValue(string value)
    {
        Value = value;
    }

    public void AppendContentTo(StringBuilder xmlResult)
    {
        if (Children.Count == 0 && string.IsNullOrEmpty(Value))
        {
            xmlResult.Append("<" + TagName + "/>");
            return;
        }

        xmlResult.Append("<" + TagName + Attributes + ">");
        foreach (var child in Children)
        {
            xmlResult.Append(child.ToString());
        }
        xmlResult.Append(Value);
        xmlResult.Append("</" + TagName + ">");
    }
}