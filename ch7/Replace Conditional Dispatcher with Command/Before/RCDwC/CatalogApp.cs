using System.Text;
using System.Xml.Linq;

namespace RCDwC
{
    public class CatalogApp
    {
        public const string NewWorkshop = "NewWorkshop";
        public const string AllWorkshops = "AllWorkshops";
        public const string AllWorkshopsStylesheet = "AllWorkshopsStylesheet";
        public const string Unknown = "Unknown";

        public HandlerResponse ExecuteActionAndGetResponse(string actionName, Dictionary<string, string> parameters)
        {
            if (actionName == NewWorkshop)
            {
                string nextWorkshopId = WorkshopManager.GetNextWorkshopId();
                StringBuilder newWorkshopContents = WorkshopManager.CreateNewFileFromTemplate(
                    nextWorkshopId,
                    WorkshopManager.GetWorkshopDir(),
                    WorkshopManager.GetWorkshopTemplate());
                WorkshopManager.AddWorkshop(newWorkshopContents);
                parameters.Add("id", nextWorkshopId);
                return ExecuteActionAndGetResponse(AllWorkshops, parameters);
            }
            
            if (actionName == AllWorkshops)
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
                return new HandlerResponse(new StringBuilder(formattedXml), AllWorkshopsStylesheet);
            }

            return new HandlerResponse(new StringBuilder(), Unknown);
        }

        private string GetFormattedData(string xml)
        {
            var workshops = XElement.Parse(xml);
            workshops.SetAttributeValue("name", WorkshopManager.CurWorkshop);
            return workshops.ToString();
        }
    }
}
