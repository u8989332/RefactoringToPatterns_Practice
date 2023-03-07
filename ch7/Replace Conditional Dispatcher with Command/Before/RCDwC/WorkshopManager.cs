using System.Text;

namespace RCDwC;

public static class WorkshopManager
{
    public static StringBuilder CurWorkshop { get; private set; } = new StringBuilder();
    public static string GetNextWorkshopId()
    {
        return "Shop1";
    }

    public static StringBuilder CreateNewFileFromTemplate(string nextWorkshopId, string workshopDir, string workshopTemplate)
    {
        return new StringBuilder(string.Format(workshopTemplate, workshopDir, nextWorkshopId));
    }

    public static string GetWorkshopDir()
    {
        return "D:";
    }

    public static string GetWorkshopTemplate()
    {
        return "{0}\\{1}";
    }

    public static void AddWorkshop(StringBuilder newWorkshopContents)
    {
        CurWorkshop = newWorkshopContents;
    }

    public static WorkshopRepository GetWorkshopRepository()
    {
        return new WorkshopRepository();
    }
}