using System.Text;

namespace IPCwFM;

public class DOMBuilder : IOutputBuilder
{
    private StringBuilder sb = new StringBuilder();

    public DOMBuilder(string rootName)
    {
        sb.Append("I am DOM" + rootName);
    }

    public void AddBelow(string name)
    {
        sb.Append(name);
    }

    public string Run()
    {
        return sb.ToString();
    }
}