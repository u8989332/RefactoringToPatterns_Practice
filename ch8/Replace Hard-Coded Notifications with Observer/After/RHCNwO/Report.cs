namespace RHCNwO;

public class Report
{
    private readonly List<IReportListener> _observers = new List<IReportListener>();

    public void AddObserver(IReportListener listener)
    {
        _observers.Add(listener);
    }

    public void AddReport(ReportMessage reportMessage)
    {
        foreach (var observer in _observers)
        {
            observer.AddReport(this, reportMessage);
        }
    }
}