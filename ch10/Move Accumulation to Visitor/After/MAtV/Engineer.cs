namespace MAtV;

public class Engineer : AbstractEmployee
{
    public int BugResolved()
    {
        return 5;
    }

    public int CodeLineChanged()
    {
        return 204;
    }

    public override void Accept(IEmployeeVisitor employeeVisitor)
    {
        employeeVisitor.VisitEngineer(this);
    }
}