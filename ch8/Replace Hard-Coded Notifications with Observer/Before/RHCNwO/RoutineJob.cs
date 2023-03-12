namespace RHCNwO;

public class RoutineJob
{
    public void Write(Report report)
    {
        report.AddReport(new ReportMessage(){Title = "Urgent"});
    }
}