namespace MAtV;

public class ProjectManager : AbstractEmployee
{
    public string IsTaskOnTime()
    {
        return "Yes";
    }

    public string IsResourceEnough()
    {
        return "No";
    }

    public override void Accept(IEmployeeVisitor employeeVisitor)
    {
        employeeVisitor.VisitProjectManager(this);
    }
}