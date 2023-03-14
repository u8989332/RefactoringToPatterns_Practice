namespace UIwA;

public class Document
{
    public Element CreateElement(string name)
    {
        return Element.CreateElement(name);
    }

    public Element CreateTextNode(string value)
    {
        return Element.CreateTextNode(value);
    }
}