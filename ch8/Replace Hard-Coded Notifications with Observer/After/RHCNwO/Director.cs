namespace RHCNwO;

public class Director : IReportListener
{
    private readonly Report _report;
    private readonly RoutineJob _routineJob = new RoutineJob();
    public string AcceptContent { get; set; } = string.Empty;

    protected Report CreateReport()
    {
        Report report = new Report();
        report.AddObserver(this);
        return report;
    }


    public Director()
    {
        _report = CreateReport();
        _routineJob.Write(_report);

    }

    public void AddReport(Report report, ReportMessage reportMessage)
    {
        AcceptContent += "New Report: " + reportMessage.Title;
    }
}