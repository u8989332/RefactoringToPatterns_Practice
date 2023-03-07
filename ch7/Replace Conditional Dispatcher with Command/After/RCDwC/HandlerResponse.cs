using System.Text;

namespace RCDwC;

public class HandlerResponse
{
    public StringBuilder StringBuilder { get; }
    public string AllWorkshopsStylesheet { get; }

    public HandlerResponse(StringBuilder stringBuilder, string allWorkshopsStylesheet)
    {
        StringBuilder = stringBuilder;
        AllWorkshopsStylesheet = allWorkshopsStylesheet;
    }
}