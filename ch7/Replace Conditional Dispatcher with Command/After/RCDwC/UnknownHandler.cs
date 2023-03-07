using System.Text;

namespace RCDwC;

public class UnknownHandler : Handler
{
    public UnknownHandler(CatalogApp catalogApp) : base(catalogApp)
    {
    }

    public override HandlerResponse Execute(Dictionary<string, string> parameters)
    {
        return new HandlerResponse(new StringBuilder(), CatalogApp.Unknown);
    }
}