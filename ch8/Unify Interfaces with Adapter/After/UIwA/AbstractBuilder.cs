namespace UIwA;

public abstract class AbstractBuilder
{
    protected IXMLNode RootNode;
    protected IXMLNode Current;
    public void AddChild(string childName)
    {
        IXMLNode childNode = CreateNode(childName);
        SetParent(Current);
        Current.Add(childNode);
        Current = childNode;
    }

    protected abstract IXMLNode CreateNode(string childName);
    public abstract void AddSibling(string siblingName);

    protected virtual void SetParent(IXMLNode node)
    {

    }
}