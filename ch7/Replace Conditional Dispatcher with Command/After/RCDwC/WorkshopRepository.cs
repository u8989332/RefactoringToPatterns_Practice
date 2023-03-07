namespace RCDwC;

public class WorkshopRepository
{
    public IEnumerable<string> Ids { get; } = new List<string>(){"1"};

    public Workshop GetWorkshop(string id)
    {
        return new Workshop();
    }
}