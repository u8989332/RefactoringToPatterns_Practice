namespace RHCNwO;

public class AccountReport : Report
{
    private readonly Director _director;
    public AccountReport(Director director)
    {
        _director = director;
    }

    public override void AddReport(ReportMessage reportMessage)
    {
        _director.AddReport(this, reportMessage);
    }
}