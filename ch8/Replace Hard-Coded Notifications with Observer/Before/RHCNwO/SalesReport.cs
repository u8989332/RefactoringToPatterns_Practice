namespace RHCNwO;

public class SalesReport : Report
{
    private readonly Manager _manager;
    public SalesReport(Manager manager)
    {
        _manager = manager;
    }

    public override void AddReport(ReportMessage reportMessage)
    {
        _manager.AddReport(this, reportMessage);
    }
}