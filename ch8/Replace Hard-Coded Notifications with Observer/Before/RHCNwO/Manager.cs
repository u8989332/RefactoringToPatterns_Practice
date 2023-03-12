namespace RHCNwO;

public class Manager
{
    private readonly Report _report;
    private readonly RoutineJob _routineJob = new RoutineJob();
    public string AcceptContent { get; set; } = string.Empty;

    protected Report CreateReport()
    {
        return new SalesReport(this);
    }


    public Manager()
    {
        _report = CreateReport();
        _routineJob.Write(_report);

    }

    public void AddReport(Report report, ReportMessage reportMessage)
    {
        AcceptContent += "Process Report: " + reportMessage.Title;
    }
}