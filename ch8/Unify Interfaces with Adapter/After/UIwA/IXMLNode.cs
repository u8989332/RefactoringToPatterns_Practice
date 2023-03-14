using System.Text;

namespace UIwA;

public interface IXMLNode
{
    void Add(IXMLNode childNode);
    void AddAttribute(string name, string value);
    void AddValue(string value);
    void AppendContentTo(StringBuilder xmlResult);
}