using System.Text;

namespace MAtV;

public class Director : IEmployeeVisitor
{
    private List<IEmployee> _employees = new List<IEmployee>();
    private StringBuilder _result;

    public Director()
    {
        _employees.Add(new Engineer());
        _employees.Add(new ProjectManager());
        _employees.Add(new MarketingManager());
        _employees.Add(new Bookkeeper());
    }

    public string TodayWorkReport()
    {
        _result = new StringBuilder();
        foreach (var employee in _employees)
        {
            employee.Accept(this);
        }

        return _result.ToString();
    }

    public void VisitBookkeeper(Bookkeeper bookkeeper)
    {
        _result.AppendLine("Transactions ok? " + bookkeeper.AreTransactionsOk());
        _result.AppendLine("Balance: " + bookkeeper.Balance());
    }

    public void VisitMarketingManager(MarketingManager marketingManager)
    {
        _result.AppendLine("Increase fans: " + marketingManager.IncreaseFans());
    }

    public void VisitProjectManager(ProjectManager projectManager)
    {
        _result.AppendLine("Task on time? " + projectManager.IsTaskOnTime());
        _result.AppendLine("Resource enough? " + projectManager.IsResourceEnough());
    }

    public void VisitEngineer(Engineer engineer)
    {
        _result.AppendLine("Bug resolved: " + engineer.BugResolved());
        _result.AppendLine("Code line changed: " + engineer.CodeLineChanged());
    }
}