using System.Text;
using System.Xml.Linq;

namespace ECwB;

public class TagBuilder
{
    private int _outputBufferSize = 0;
    private readonly TagNode _rootNode;
    private TagNode _currentNode;
    private const int TagCharsSize = 5;
    private const int AttributeCharsSize = 4;

    public int BufferSize => _outputBufferSize;

    public TagBuilder(string rootTagName)
    {
        _rootNode = new TagNode(rootTagName);
        _currentNode = _rootNode;
        IncrementBufferSizeByTagLength(rootTagName);
    }

    public void AddChild(string childTagName)
    {
        AddTo(_currentNode, childTagName);
    }


    public void AddSibling(string siblingTagName)
    {
        AddTo(_currentNode.Parent, siblingTagName);
    }

    public string ToXml()
    {
        StringBuilder xmlResult = new StringBuilder(_outputBufferSize);
        _rootNode.AppendContentTo(xmlResult);
        return xmlResult.ToString();
    }

    public void AddToParent(string parentTagName, string childTagName)
    {
        TagNode parentNode = FindParentBy(parentTagName);
        if (parentNode == null)
        {
            throw new InvalidOperationException("Missing parent tag: " + parentTagName);
        }

        AddTo(parentNode, childTagName);
    }

    public void AddAttribute(string name, string value)
    {
        _currentNode.AddAttribute(name, value);
        IncrementBufferSizeByAttributeLength(name, value);
    }

    public void AddValue(string value)
    {
        _currentNode.AddValue(value);
        IncrementBufferSizeByValueLength(value);
    }

    private void AddTo(TagNode parentNode, string tagName)
    {
        _currentNode = new TagNode(tagName);
        parentNode.Add(_currentNode);
        IncrementBufferSizeByTagLength(tagName);
    }

    private TagNode FindParentBy(string parentName)
    {
        TagNode parentNode = _currentNode;
        while (parentNode != null)
        {
            if (parentName == parentNode.TagName)
            {
                return parentNode;
            }

            parentNode = parentNode.Parent;
        }

        return null;
    }
    private void IncrementBufferSizeByTagLength(string tag)
    {
        int sizeOfOpenAndCloseTags = tag.Length * 2;
        _outputBufferSize += sizeOfOpenAndCloseTags + TagCharsSize;
    }

    private void IncrementBufferSizeByAttributeLength(string name, string value)
    {
        _outputBufferSize += name.Length + value.Length + AttributeCharsSize;
    }

    private void IncrementBufferSizeByValueLength(string value)
    {
        _outputBufferSize += value.Length;
    }

}