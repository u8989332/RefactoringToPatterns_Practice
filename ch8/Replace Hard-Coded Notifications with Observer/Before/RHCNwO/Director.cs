namespace RHCNwO;

public class Director
{
    private readonly Report _report;
    private readonly RoutineJob _routineJob = new RoutineJob();
    public string AcceptContent { get; set; } = string.Empty;

    protected Report CreateReport()
    {
        return new AccountReport(this);
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