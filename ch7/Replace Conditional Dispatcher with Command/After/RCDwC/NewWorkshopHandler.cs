using System.Text;

namespace RCDwC;

public class NewWorkshopHandler : Handler
{
    public NewWorkshopHandler(CatalogApp catalogApp) : base(catalogApp)
    {
    }
    public override HandlerResponse Execute(Dictionary<string, string> parameters)
    {
        CreateNewWorkshop(parameters);
        return _catalogApp.ExecuteActionAndGetResponse(CatalogApp.AllWorkshops, parameters);
    }

    private void CreateNewWorkshop(Dictionary<string, string> parameters)
    {
        string nextWorkshopId = WorkshopManager.GetNextWorkshopId();
        WorkshopManager.AddWorkshop(NewWorkshopContents(nextWorkshopId));
        parameters.Add("id", nextWorkshopId);
    }

    private StringBuilder NewWorkshopContents(string nextWorkshopId)
    {
        return WorkshopManager.CreateNewFileFromTemplate(
            nextWorkshopId,
            WorkshopManager.GetWorkshopDir(),
            WorkshopManager.GetWorkshopTemplate());
    }
}