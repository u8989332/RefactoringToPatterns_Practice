namespace RHCNwO;

public class Manager : IReportListener
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