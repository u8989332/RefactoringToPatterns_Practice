namespace MAtV;

public class Bookkeeper : AbstractEmployee
{
    public string AreTransactionsOk()
    {
        return "Yes";
    }

    public int Balance()
    {
        return 9741526;
    }

    public override void Accept(IEmployeeVisitor employeeVisitor)
    {
        employeeVisitor.VisitBookkeeper(this);
    }
}