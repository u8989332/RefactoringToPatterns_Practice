namespace RCDwC;

public abstract class Handler
{
    protected readonly CatalogApp _catalogApp;

    protected Handler(CatalogApp catalogApp)
    {
        _catalogApp = catalogApp;
    }

    public abstract HandlerResponse Execute(Dictionary<string, string> parameters);
}