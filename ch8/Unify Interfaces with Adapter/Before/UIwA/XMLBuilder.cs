using System.Text;

namespace UIwA;

public class XMLBuilder : AbstractBuilder
{
    private readonly TagNode _rootNode;
    private TagNode _currentNode;

    public XMLBuilder(string rootTagName)
    {
        _rootNode = new TagNode(rootTagName);
        _currentNode = _rootNode;
    }

    public void AddChild(string childTagName)
    {
        AddTo(_currentNode, childTagName);
    }

    public void AddSibling(string siblingTagName)
    {
        AddTo(_currentNode.Parent, siblingTagName);
    }

    public void AddAttribute(string name, string value)
    {
        _currentNode.AddAttribute(name, value);
    }

    public void AddValue(string value)
    {
        _currentNode.AddValue(value);
    }

    public string ToXml()
    {
        StringBuilder xmlResult = new StringBuilder();
        _rootNode.AppendContentTo(xmlResult);
        return xmlResult.ToString();
    }

    private void AddTo(TagNode parentNode, string tagName)
    {
        _currentNode = new TagNode(tagName);
        parentNode.Add(_currentNode);
    }
}