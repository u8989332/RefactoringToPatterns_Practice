using System.Collections;
using System.Text;

namespace MAtV;

public class Director
{
    private ArrayList _employees = new ArrayList();

    public Director()
    {
        _employees.Add(new Engineer());
        _employees.Add(new ProjectManager());
        _employees.Add(new MarketingManager());
        _employees.Add(new Bookkeeper());
    }

    public string TodayWorkReport()
    {
        StringBuilder result = new StringBuilder();
        foreach (var employee in _employees)
        {
            if (employee is Engineer engineer)
            {
                result.AppendLine("Bug resolved: " + engineer.BugResolved());
                result.AppendLine("Code line changed: " + engineer.CodeLineChanged());
            }
            else if (employee is ProjectManager projectManager)
            {
                result.AppendLine("Task on time? " + projectManager.IsTaskOnTime());
                result.AppendLine("Resource enough? " + projectManager.IsResourceEnough());
            }
            else if (employee is MarketingManager marketingManager)
            {
                result.AppendLine("Increase fans: " + marketingManager.IncreaseFans());
            }
            else if (employee is Bookkeeper bookkeeper)
            {
                result.AppendLine("Transactions ok? " + bookkeeper.AreTransactionsOk());
                result.AppendLine("Balance: " + bookkeeper.Balance());
            }
        }

        return result.ToString();
    }
}