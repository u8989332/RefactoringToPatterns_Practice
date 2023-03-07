namespace RCDwC
{
    public class CatalogApp
    {
        public const string NewWorkshop = "NewWorkshop";
        public const string AllWorkshops = "AllWorkshops";
        public const string AllWorkshopsStylesheet = "AllWorkshopsStylesheet";
        public const string Unknown = "Unknown";
        private readonly Dictionary<string, Handler> _handlers;

        public CatalogApp()
        {
            _handlers = new Dictionary<string, Handler>
            {
                { NewWorkshop, new NewWorkshopHandler(this) },
                { AllWorkshops, new AllWorkshopHandler(this) },
                { Unknown, new UnknownHandler(this) }
            };
        }

        public HandlerResponse ExecuteActionAndGetResponse(string actionName, Dictionary<string, string> parameters)
        {
            return _handlers[actionName].Execute(parameters);
        }
    }
}
