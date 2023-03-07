using System.Text;
using System.Xml.Linq;

namespace RCDwC;

public class AllWorkshopHandler : Handler
{
    public AllWorkshopHandler(CatalogApp catalogApp) : base(catalogApp)
    {
    }

    public override HandlerResponse Execute(Dictionary<string, string> parameters)
    {
        XElement allWorkshopXml = new XElement("workshops");
        WorkshopRepository repository = WorkshopManager.GetWorkshopRepository();
        foreach (var id in repository.Ids)
        {
            Workshop workshop = repository.GetWorkshop(id);
            XElement workshopNode = new XElement("workshop");
            workshopNode.SetAttributeValue("id", workshop.Id);
            workshopNode.SetAttributeValue("name", workshop.Name);
            workshopNode.SetAttributeValue("status", workshop.Status);
            workshopNode.SetAttributeValue("duration", workshop.Duration);
            allWorkshopXml.Add(workshopNode);
        }

        string formattedXml = GetFormattedData(allWorkshopXml.ToString());
        return new HandlerResponse(new StringBuilder(formattedXml), CatalogApp.AllWorkshopsStylesheet);
    }

    private string GetFormattedData(string xml)
    {
        var workshops = XElement.Parse(xml);
        workshops.SetAttributeValue("name", WorkshopManager.CurWorkshop);
        return workshops.ToString();
    }
}